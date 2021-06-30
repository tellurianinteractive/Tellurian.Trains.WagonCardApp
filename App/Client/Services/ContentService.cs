using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WagonCardApp.Contract;

namespace WagonCardApp.Client.Services
{
    public class ContentService : IContentService
    {
        private readonly HttpClient Client;
        public ContentService(HttpClient client)
        {
            Client = client;
        }
        public async Task<TextContent?> GetTextContent(string content)
        {
            return await Client.GetFromJsonAsync<TextContent>($"api/content/{content}");
        }
    }
}
