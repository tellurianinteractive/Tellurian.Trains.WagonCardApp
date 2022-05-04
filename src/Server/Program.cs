using Microsoft.AspNetCore.Server.Kestrel.Core;
using Tellurian.WagonCardApp.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IContentService, ContentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRequestLocalization(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
    options.AddSupportedCultures("en", "de", "da", "sv");
});
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
