using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LocalisationGlobalizationI18nText;
using LocalisationGlobalizationI18nText.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddI18nText();
builder.Services.AddScoped<Translator>();

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("fr");


await builder.Build().RunAsync();