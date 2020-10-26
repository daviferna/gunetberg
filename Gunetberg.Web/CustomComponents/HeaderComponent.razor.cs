using Gunetberg.Web.Providers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Handlers;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class HeaderComponent : ComponentBase
    {
        [Inject]
        private HttpClientProvider _httpClientProvider { get; set; }

        public int Progress { get; set; }


        protected override void OnInitialized()
        {
            _httpClientProvider.ProgressHandler.HttpSendProgress += OnSendProgressChanged;
            _httpClientProvider.ProgressHandler.HttpReceiveProgress += OnReceiveProgressChanged;
        }

        private void OnSendProgressChanged(object sender, HttpProgressEventArgs e)
        {
            Progress = e.ProgressPercentage / 2;
            Console.WriteLine("Progreso");
            StateHasChanged();
        }
       
        private void OnReceiveProgressChanged(object sender, HttpProgressEventArgs e)
        {
            Progress = e.ProgressPercentage / 2 + 50;
            Console.WriteLine($"Progreso {e.ProgressPercentage / 2 + 50}");
            StateHasChanged();
        }
    }
}
