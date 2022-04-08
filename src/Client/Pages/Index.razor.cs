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

namespace Client.Pages
{
    public partial class Index
    {
        private bool arrows = false;
        private bool bullets = true;
        private bool autocycle = true;
        private Transition transition = Transition.Fade;
    }
}