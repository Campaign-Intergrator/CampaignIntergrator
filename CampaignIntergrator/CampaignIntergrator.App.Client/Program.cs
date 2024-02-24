using CampaignIntergrator.App.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.HostEnvironment.BaseAddress -> https://localhost:7102/
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7102/") });

await builder.Build().RunAsync();
