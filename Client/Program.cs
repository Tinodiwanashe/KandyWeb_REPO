
using Client.Infrastructure.Managers.Preferences;
using Client.Infrastructure.Settings;
using Client.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
//using Shared.Constants.Localization;
using System.Globalization;

var builder = WebAssemblyHostBuilder
              .CreateDefault(args)
              .AddRootComponents()
              .AddClientServices()
              .AddMicrosoftAuthentication();
var host = builder.Build();

var storageService = host.Services.GetRequiredService<ClientPreferenceManager>();
if (storageService != null)
{
    //CultureInfo culture;
    var preference = await storageService.GetPreference() as ClientPreference;
    //if (preference != null)
    //    culture = new CultureInfo(preference.LanguageCode);
    //else
    //    culture = new CultureInfo(LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US");
    //CultureInfo.DefaultThreadCurrentCulture = culture;
    //CultureInfo.DefaultThreadCurrentUICulture = culture;
}
    await builder.Build().RunAsync();
