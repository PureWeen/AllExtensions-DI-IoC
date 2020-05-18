using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;
using AllExtensions.View;

namespace AllExtensions
{
    public class MainViewModel : IMainViewModel
    {
        public MainViewModel(ILogger<MainViewModel> logger, IHttpClientFactory httpClientFactory)
        {
            var httpClient = httpClientFactory.CreateClient();
            logger.LogCritical("Always be logging!");
            Hello = "Hello from IoC";

            PushToSecondPage = new Command(() =>
            {
                Shell.Current.GoToAsync(nameof(SecondPage));
            });
        }

        public ICommand PushToSecondPage { get; }
        public string Hello { get; set; }
    }
}
