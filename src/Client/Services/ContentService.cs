using System.Globalization;

namespace Tellurian.WagonCardApp.Client.Services;

/// <summary>
/// Reads the markdown text pages that are shipped with the app in wwwroot/content.
/// A page is named {content}.{language}.md, with {content}.md as the English fallback.
/// Being static files, they are cached by the service worker and also work offline.
/// </summary>
public sealed class ContentService(HttpClient client) : IContentService
{
    private const string ContentFolder = "content";
    private const string MarkdownType = "MD";
    private const string HtmlMediaType = "text/html";

    /// <summary>Returns the page in the user's language, or in English, or null if it does not exist.</summary>
    public async Task<TextContent?> GetTextContent(string content)
    {
        var language = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        return await GetMarkdownAsync($"{ContentFolder}/{content}.{language}.md")
            ?? await GetMarkdownAsync($"{ContentFolder}/{content}.md");
    }

    private async Task<TextContent?> GetMarkdownAsync(string path)
    {
        using var response = await client.GetAsync(path);
        // A missing file can be answered with index.html by the server's fallback route.
        if (!response.IsSuccessStatusCode || response.Content.Headers.ContentType?.MediaType == HtmlMediaType) return null;
        var text = await response.Content.ReadAsStringAsync();
        return new TextContent(text, MarkdownType, response.Content.Headers.LastModified ?? DateTimeOffset.Now);
    }
}
