using System.Net.Http.Json;

namespace Tellurian.WagonCardApp.Client.Services;

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
