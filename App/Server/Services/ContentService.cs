using WagonCardApp.Contract;
using System.Threading.Tasks;
using WagonCardApp.Server.Extensions;

namespace WagonCardApp.Server.Services
{
    public class ContentService : IContentService
    {
        private const string MarkdownPath = "content/markdown";
        public async Task<TextContent?> GetTextContent(string content) =>
            await LanguageService.CurrentCulture.GetMarkdownAsync(MarkdownPath, content).ConfigureAwait(false);
    }
}
