using AWMonitor.Models;
using AWMonitor.Services;
using AWMonitor.ViewModels;
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
    public partial class SettingsPage : ContentPage
    {
        SettingsVM viewModel;

        public SettingsPage()
        {
            InitializeComponent();

            viewModel = new SettingsVM();

            BindingContext = viewModel;

            Title = "Configurações";
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadCurrentSettings();
        }

        private async void btnReadQr_Clicked(object sender, EventArgs e)
        {
            await viewModel.ReadQrCode();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            await viewModel.Save();
        }
    }
}