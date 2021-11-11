using Tellurian.WagonCardApp.Server.Extensions;
using WagonCardApp.Server.Services;

namespace Tellurian.WagonCardApp.Server.Services;

public class ContentService : IContentService
{
    private const string MarkdownPath = "content/markdown";
    public async Task<TextContent?> GetTextContent(string content) =>
        await LanguageService.CurrentCulture.GetMarkdownAsync(MarkdownPath, content).ConfigureAwait(false);
}
