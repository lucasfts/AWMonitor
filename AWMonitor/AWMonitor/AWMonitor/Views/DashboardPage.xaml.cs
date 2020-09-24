using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AWMonitor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();

            Title = "Dashboard";

            webView.WidthRequest = Width;
            webView.HeightRequest = Height;
        }

        private void webView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            activity.IsVisible = activity.IsRunning = true;
        }

        private async void webView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            await Task.Delay(2000);
            activity.IsVisible = activity.IsRunning = false;
        }

    }
}