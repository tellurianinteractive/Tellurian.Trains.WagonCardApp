using Microsoft.JSInterop;

namespace Tellurian.WagonCardApp.Client.Services;

/// <summary>
/// Lets the user save text produced by the app as a file, using the browser's download.
/// </summary>
public sealed class FileDownloader(IJSRuntime js) : IAsyncDisposable
{
    private const string ModulePath = "./js/fileDownload.js";
    private IJSObjectReference? _module;

    /// <summary>Starts a download of the text. Returns false if the browser refused.</summary>
    public async ValueTask<bool> DownloadTextAsync(string fileName, string text, string contentType, CancellationToken cancellationToken = default)
    {
        try
        {
            _module ??= await js.InvokeAsync<IJSObjectReference>("import", cancellationToken, ModulePath);
            await _module.InvokeVoidAsync("downloadText", cancellationToken, fileName, text, contentType);
            return true;
        }
        catch (JSException)
        {
            return false;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_module is null) return;
        try
        {
            await _module.DisposeAsync();
        }
        catch (JSDisconnectedException)
        {
            // The page is already gone, so there is nothing left to release.
        }
    }
}
