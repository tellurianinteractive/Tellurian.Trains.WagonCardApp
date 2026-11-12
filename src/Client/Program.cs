global using Tellurian.WagonCardApp.Client;
global using Tellurian.WagonCardApp.Shared;
global using Microsoft.Extensions.Localization;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tellurian.WagonCardApp.Client.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddScoped<LocalStorage>();
builder.Services.AddScoped<FileDownloader>();
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddPWAUpdater();

await builder.Build().RunAsync();
