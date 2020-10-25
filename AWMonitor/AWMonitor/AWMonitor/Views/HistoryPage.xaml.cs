using AWMonitor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AWMonitor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        private static ISettingsService _settingsService => DependencyService.Get<ISettingsService>();

        public HistoryPage()
        {
            InitializeComponent();

            Title = "Histórico";

            webView.WidthRequest = Width;
            webView.HeightRequest = Height;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var settings = await _settingsService.GetFirstOrDefaultAsync();
            webView.Source = $"{settings.Url}/history.html";
        }

        private void webView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            activity.IsVisible = activity.IsRunning = true;
        }

        private void webView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            activity.IsVisible = activity.IsRunning = false;
        }
    }
}