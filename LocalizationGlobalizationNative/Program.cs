using System.Globalization;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Blazored.LocalStorage.StorageOptions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LocalizationGlobalizationNative;
using LocalizationGlobalizationNative.Extensions;
using Microsoft.Extensions.Localization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddLocalization();
builder.Services.AddBlazoredLocalStorage(
    config => config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );

var app = builder.Build();

// Setting Locale Storage Localization
var localStorage = app.Services.GetRequiredService<ILocalStorageService>();

CultureInfo currentCulture;

var codeLang = await localStorage.GetItemAsStringAsync("codeLang");

if (codeLang is null)
{
    codeLang = "fr"; // User.DefaultLang
    await localStorage.SetItemAsync("codeLang", codeLang);
}

currentCulture = new CultureInfo(codeLang);

CultureInfo.DefaultThreadCurrentCulture = currentCulture;
CultureInfo.DefaultThreadCurrentUICulture = currentCulture;
// End Setting

// await app.SetLocaleStorageLocalization();

await app.RunAsync();