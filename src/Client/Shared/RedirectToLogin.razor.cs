using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using Client;
using Client.Shared;
using MudBlazor;
using Blazored.LocalStorage;
using Client.Infrastructure.Managers.Preferences;

namespace Client.Shared
{
    public partial class RedirectToLogin
    {
        protected override async Task OnInitializedAsync()
        {
            Navigation.NavigateTo($"authentication/login?returnUrl={Uri.EscapeDataString(Navigation.Uri)}");
            await Task.CompletedTask;
        }
    }
}