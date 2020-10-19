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
    public partial class CreateSettingsPage : ContentPage
    {
        CreateSettingsVM viewModel;

        public CreateSettingsPage()
        {
            InitializeComponent();

            viewModel = new CreateSettingsVM();
            BindingContext = viewModel;
        }

        private void btnContinue_Clicked(object sender, EventArgs e)
        {
            viewModel.CreateAndContinue();
        }

        private async void btnReadQr_Clicked(object sender, EventArgs e)
        {
            await viewModel.ReadQrCode();
        }
    }
}