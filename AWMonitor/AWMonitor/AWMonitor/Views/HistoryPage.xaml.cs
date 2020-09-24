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
        public HistoryPage()
        {
            InitializeComponent();

            Title = "Histórico";

            webView.WidthRequest = Width;
            webView.HeightRequest = Height;
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