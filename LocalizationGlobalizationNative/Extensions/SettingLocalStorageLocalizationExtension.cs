using System.Globalization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace LocalizationGlobalizationNative.Extensions;

public static class SettingLocalStorageLocalizationExtension
{
   public static async Task<WebAssemblyHost> SetLocaleStorageLocalization(this WebAssemblyHost app)
   {
      var localStorage = app.Services.GetRequiredService<ILocalStorageService>();

      var codeLang = await localStorage.GetItemAsStringAsync("codeLang");

      if (codeLang is null)
      {
         codeLang = "fr"; // User.DefaultLang
         await localStorage.SetItemAsync("codeLang", codeLang);
      }

      CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(codeLang);
      CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(codeLang);
      
      return app;
   }
}