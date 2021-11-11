using System.Threading.Tasks;

namespace Tellurian.WagonCardApp.Shared;

public interface IContentService
{
    Task<TextContent?> GetTextContent(string content);
}
