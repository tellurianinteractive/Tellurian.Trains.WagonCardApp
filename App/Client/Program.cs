using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WagonCardApp.Client.Services;
using WagonCardApp.Contract;

namespace WagonCardApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            builder.Services.AddBlazoredLocalStorage(config =>
                config.JsonSerializerOptions.WriteIndented = true);

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IContentService, ContentService>();

            await builder.Build().RunAsync();
        }
    }
}
