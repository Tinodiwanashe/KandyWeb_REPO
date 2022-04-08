using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Client.Infrastructure.Managers;
using Client.Infrastructure.Managers.Preferences;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Client;
using Blazored.LocalStorage;

namespace Client.Extensions
{
    public static class WebAssemblyHostBuilderExtensions
    {
        public static WebAssemblyHostBuilder AddRootComponents(this WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            return builder;
        }

        //public static IServiceCollection AddManagers(this IServiceCollection services)
        //{
        //    var managers = typeof(IManager);

        //    var types = managers
        //        .Assembly
        //        .GetExportedTypes()
        //        .Where(t => t.IsClass && !t.IsAbstract)
        //        .Select(t => new
        //        {
        //            Service = t.GetInterface($"I{t.Name}"),
        //            Implementation = t
        //        })
        //        .Where(t => t.Service != null);

        //    foreach (var type in types)
        //    {
        //        if (managers.IsAssignableFrom(type.Service))
        //        {
        //            services.AddTransient(type.Service, type.Implementation);
        //        }
        //    }

        //    return services;
        //}

        public static WebAssemblyHostBuilder AddClientServices(this WebAssemblyHostBuilder builder)
        {
            builder
                .Services
                //.AddLocalization(options =>
                //{
                //    options.ResourcesPath = "Resources";
                //})
                .AddBlazoredLocalStorage()
                .AddMudServices(configuration =>
                {
                    configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                    configuration.SnackbarConfiguration.HideTransitionDuration = 100;
                    configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
                    configuration.SnackbarConfiguration.VisibleStateDuration = 3000;
                    configuration.SnackbarConfiguration.ShowCloseIcon = false;
                })
            //.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
            .AddScoped<ClientPreferenceManager>();
            //.AddScoped<BlazorHeroStateProvider>()
            //.AddScoped<AuthenticationStateProvider, BlazorHeroStateProvider>()
            //.AddManagers();
            //.AddExtendedAttributeManagers()
            //.AddTransient<AuthenticationHeaderHandler>()
            //.AddHttpMessageHandler<AuthenticationHeaderHandler>();
            //builder.Services.AddHttpClientInterceptor();
            return builder;
        }

        //set up HTTPclient with Autorisationmessagehandler in blazor web assembly. Set it up once and forget abut it
        //When an HTTP request is sent, a message handler such as the blazor web assembly's Authorisation message handler fetches the token using IAccessToken Provider
        //Install-Package Microsoft.Extensions.Http in Nuget package manager console
        //replace this code with the line underneath builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        //public static WebAssemblyHostBuilder AddWebAPI(this WebAssemblyHostBuilder builder)
        //{
        //    //Support for HttpClient instances is added that include access tokens when making requests to the server project.
        //    //The AddHttpClient extension method prepares  an httpclient for you by configuring the base address
        //    //EventManagement.Server is the assembly name of the Web API
        //    builder.Services.AddHttpClient("EventManagement.Server", client =>
        //    {
        //        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);//new Uri(builder.Configuration["ApiUrl"]); //
        //    })
        //    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
        //    //.AddHttpMessageHandler(sp => sp.GetRequiredService<AuthorizationMessageHandler>()
        //    //                        .ConfigureHandler(new[] { builder.Configuration["ApiUrl"] },
        //    //                                          new[] { builder.Configuration["AzureAd:Scope"] }));
        //    builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("EventManagement.Server"));
        //    return builder;
        //}

        //Handle al authentication on the client side. Such as signin and signup
        //Support for authenticating users is registered in the service container with the AddMsalAuthentication (Microsoft Authentication Library) extension method provided by the Microsoft.Authentication.WebAssembly.Msal package.
        //This method sets up the services required for the app to interact with the Identity Provider(IP).
        public static WebAssemblyHostBuilder AddMicrosoftAuthentication(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddMsalAuthentication(options =>
            {
                builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
                //options.ProviderOptions.DefaultAccessTokenScopes.Add(builder.Configuration["AzureAd:Scope"]);
                //Add a pair of MsalProviderOptions for openid and offline_access DefaultAccessTokenScopes:
                options.ProviderOptions.DefaultAccessTokenScopes.Add("offline_access");
                options.ProviderOptions.DefaultAccessTokenScopes.Add("openid");
                //The framework defaults to pop - up login mode and falls back to redirect login mode if a pop - up can't be opened. 
                //Configure MSAL to use redirect login mode by setting the LoginMode property of MsalProviderOptions to redirect:
                options.ProviderOptions.LoginMode = "redirect";
            });

            return builder;
        }

        //private static void RegisterPermissionClaims(AuthorizationOptions options)
        //{
        //    foreach (var prop in typeof(Permissions).GetNestedTypes().SelectMany(c => c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)))
        //    {
        //        var propertyValue = prop.GetValue(null);
        //        if (propertyValue is not null)
        //        {
        //            options.AddPolicy(propertyValue.ToString(), policy => policy.RequireClaim(ApplicationClaimTypes.Permission, propertyValue.ToString()));
        //        }
        //    }
        //}
    }
}
