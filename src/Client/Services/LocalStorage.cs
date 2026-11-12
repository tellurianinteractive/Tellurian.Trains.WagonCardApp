using System.Text.Json;
using Microsoft.JSInterop;

namespace Tellurian.WagonCardApp.Client.Services;

/// <summary>
/// Stores objects as JSON in the browser's local storage.
/// Uses default <see cref="JsonSerializer"/> settings, which is the same format as
/// Blazored.LocalStorage used, so data saved by earlier versions can still be read.
/// </summary>
/// <remarks>
/// The browser can refuse access to local storage, for example when it is full or disabled.
/// Such failures are reported through return values instead of exceptions.
/// </remarks>
public sealed class LocalStorage(IJSRuntime js)
{
    /// <summary>Returns the stored item, or null if it is missing or cannot be read.</summary>
    public async ValueTask<T?> GetItemAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        try
        {
            var json = await js.InvokeAsync<string?>("localStorage.getItem", cancellationToken, key);
            return string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.Deserialize<T>(json);
        }
        catch (Exception ex) when (ex is JSException or JsonException)
        {
            return default;
        }
    }

    /// <summary>Stores the item. Returns false if the browser refused, typically because the storage is full.</summary>
    public async ValueTask<bool> SetItemAsync<T>(string key, T value, CancellationToken cancellationToken = default)
    {
        try
        {
            await js.InvokeVoidAsync("localStorage.setItem", cancellationToken, key, JsonSerializer.Serialize(value));
            return true;
        }
        catch (JSException)
        {
            return false;
        }
    }

    public async ValueTask<bool> ContainsKeyAsync(string key, CancellationToken cancellationToken = default)
    {
        try
        {
            return await js.InvokeAsync<string?>("localStorage.getItem", cancellationToken, key) is not null;
        }
        catch (JSException)
        {
            return false;
        }
    }

    public async ValueTask<bool> RemoveItemAsync(string key, CancellationToken cancellationToken = default)
    {
        try
        {
            await js.InvokeVoidAsync("localStorage.removeItem", cancellationToken, key);
            return true;
        }
        catch (JSException)
        {
            return false;
        }
    }
}
