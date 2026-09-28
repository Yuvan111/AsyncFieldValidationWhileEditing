using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WASMApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<IAvailabilityChecker, MockAvailabilityChecker>();

await builder.Build().RunAsync();
