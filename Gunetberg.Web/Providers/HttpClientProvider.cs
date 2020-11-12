using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Handlers;
using System.Threading.Tasks;

namespace Gunetberg.Web.Providers
{
    public class HttpClientProvider
    {
        public HttpClient HttpClient { get; }
        public ProgressMessageHandler ProgressHandler { get; }

        public HttpClientProvider(string baseAddress)
        {
            ProgressHandler = new ProgressMessageHandler();
            HttpClient = HttpClientFactory.Create(ProgressHandler);
            HttpClient.BaseAddress = new Uri(baseAddress);
        }

        
    }
}
