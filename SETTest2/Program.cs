using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SETTest2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseAddress = new Uri(builder.HostEnvironment.BaseAddress);
if (baseAddress.AbsoluteUri.Contains("github.io"))
{
    // Use hash routing for GitHub Pages
    builder.Services.AddScoped<NavigationManager>(sp =>
    {
        var navigation = sp.GetRequiredService<NavigationManager>();
        // Handle hash routing
        return navigation;
    });
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
