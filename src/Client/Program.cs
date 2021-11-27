using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LtuLunch.Client;
using LtuLunch.Client.services;
using LtuLunch.Client.state;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<LunchUpdateService>();
builder.Services.AddSingleton<LunchStateStorage>();


await builder.Build().RunAsync();
