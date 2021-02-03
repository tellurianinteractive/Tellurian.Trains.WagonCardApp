using System.Threading.Tasks;

namespace WagonCardApp.Contract
{
    public interface IContentService
    {
        Task<TextContent?> GetTextContent(string content);
    }
}