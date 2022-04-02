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
using Client.Extensions;

namespace Client.Shared
{
    public partial class MainLayout
    {
        bool _drawerOpen = true;
        //private MudTheme? _currentTheme = null;
        private bool _rightToLeft = false;
        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            //if not home page, the navbar starts open
            if (!_navigationManager.IsHomePage())
            {
                _drawerOpen = true;
            }
        }

        private async Task RightToLeftToggle()
        {
            var isRtl = await _clientPreferenceManager.ToggleLayoutDirection();
            _rightToLeft = isRtl;
            _drawerOpen = false;
        }
    }
}