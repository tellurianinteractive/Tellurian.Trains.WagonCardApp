using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using Tellurian.WagonCardApp.Client.Services;
using Tellurian.WagonCardApp.Shared;

namespace Tellurian.WagonCardApp.Client.Pages;

/// <summary>
/// Shared behaviour of the pages that edit a vehicle card: loading from and saving to
/// local storage, print preview, example and reset, and JSON download and upload.
/// </summary>
public abstract class VehicleEditorPage<T> : ComponentBase where T : Vehicle
{
    private const string JsonContentType = "application/json";
    private const string UploadErrorTitle = "ErrorInUploadedJsonFile";
    private const string SaveErrorTitle = "CouldNotSaveInBrowser";
    private const string SaveErrorMessage = "BrowserStorageMayBeFull";
    private const string DownloadErrorTitle = "CouldNotDownloadFile";
    private const string DownloadErrorMessage = "BrowserBlockedDownload";
    private static readonly JsonSerializerOptions DownloadOptions = new() { WriteIndented = true };

    [Inject] protected IStringLocalizer<App> Localizer { get; set; } = default!;
    [Inject] protected LocalStorage LocalStorage { get; set; } = default!;
    [Inject] protected NavigationManager Navigator { get; set; } = default!;
    [Inject] protected FileDownloader FileDownloader { get; set; } = default!;

    /// <summary>The vehicle being edited. Not set until <see cref="IsLoaded"/> is true.</summary>
    protected T Data { get; private set; } = default!;
    protected Owner Owner { get; private set; } = new();
    /// <summary>Resource key of the heading for <see cref="ErrorMessage"/>.</summary>
    protected string ErrorTitle { get; private set; } = string.Empty;
    protected string? ErrorMessage { get; private set; }
    protected bool IsLoaded => Data is not null;

    protected abstract string StorageKey { get; }
    protected abstract string PrintRoute { get; }
    protected abstract T CreateDefault();

    /// <summary>Returns an example vehicle, or null if this kind of vehicle has no example.</summary>
    protected virtual T? CreateExample() => null;

    /// <summary>Fills in missing or outdated data after a vehicle has been loaded, uploaded or created.</summary>
    protected virtual void Normalize(T data) { }

    protected override async Task OnInitializedAsync() => await LoadAsync();

    protected async Task LoadAsync()
    {
        Owner = await LocalStorage.GetItemAsync<Owner>(StorageKeys.Owner) ?? Owner.Default;
        SetData(await GetStoredDataAsync() ?? CreateDefault());
        ClearError();
    }

    /// <summary>Reads the saved vehicle from local storage. Override to migrate older saved data.</summary>
    protected virtual async Task<T?> GetStoredDataAsync() => await LocalStorage.GetItemAsync<T>(StorageKey);

    protected Task SaveAsync() => TrySaveAsync();

    /// <summary>
    /// Saves the owner as soon as it is changed, so it is kept even if the card is never saved.
    /// The owner is small, so this succeeds even when large images fill up the storage.
    /// </summary>
    protected async Task SaveOwnerAsync()
    {
        if (!await LocalStorage.SetItemAsync(StorageKeys.Owner, Owner)) ShowSaveError();
    }

    protected async Task PrintAsync()
    {
        if (await TrySaveAsync()) Navigator.NavigateTo(PrintRoute);
    }

    protected async Task ShowExampleAsync()
    {
        var example = CreateExample();
        if (example is null) return;
        await SaveAsync();
        SetData(example);
    }

    protected void Reset() => SetData(CreateDefault());

    protected void ClearError()
    {
        ErrorTitle = string.Empty;
        ErrorMessage = null;
    }

    protected async Task UploadAsync(InputFileChangeEventArgs e)
    {
        try
        {
            await using var stream = new MemoryStream();
            await e.File.OpenReadStream(maxAllowedSize: AppService.MaxUploadFileSize).CopyToAsync(stream);
            stream.Position = 0;
            var data = await JsonSerializer.DeserializeAsync<T>(stream) ?? CreateDefault();
            if (data.Owner is { IsEmptyOrDefault: false } owner) Owner = owner;
            SetData(data);
            ClearError();
        }
        catch (Exception ex)
        {
            ShowError(UploadErrorTitle, ex.Message);
        }
    }

    protected async Task DownloadAsync()
    {
        if (!IsLoaded) return;
        await SaveAsync();
        var json = JsonSerializer.Serialize(Data, DownloadOptions);
        var fileName = $"{Data.OperatorSignature}_{Data.VehicleClass}_{Data.VehicleNumber}.json";
        if (!await FileDownloader.DownloadTextAsync(fileName, json, JsonContentType)) ShowError(DownloadErrorTitle, Localizer[DownloadErrorMessage]);
    }

    /// <summary>Saves the owner first, so it is not lost if the vehicle data does not fit in the storage.</summary>
    private async Task<bool> TrySaveAsync()
    {
        if (!IsLoaded) return false;
        Data.Owner = Owner;
        var saved = await LocalStorage.SetItemAsync(StorageKeys.Owner, Owner) && await LocalStorage.SetItemAsync(StorageKey, Data);
        if (saved) ClearError();
        else ShowSaveError();
        return saved;
    }

    private void ShowSaveError() => ShowError(SaveErrorTitle, Localizer[SaveErrorMessage]);

    private void ShowError(string title, string message)
    {
        ErrorTitle = title;
        ErrorMessage = message;
    }

    private void SetData(T data)
    {
        data.Owner = Owner;
        Normalize(data);
        Data = data;
    }
}
