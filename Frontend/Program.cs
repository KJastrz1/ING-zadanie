using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Frontend.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");


builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);

var backendUrl = builder.Configuration.GetValue<string>("BackendUrl");

if (string.IsNullOrEmpty(backendUrl))
{
    throw new InvalidOperationException("BackendUrl configuration is missing.");
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(backendUrl) });

await builder.Build().RunAsync();