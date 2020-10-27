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
    public partial class ChangePasswordPage : ContentPage
    {
        ChangePasswordVM viewModel;

        public ChangePasswordPage(string phone, int code)
        {
            InitializeComponent();

            viewModel = new ChangePasswordVM { Phone = phone, ChangePasswordCode = code };
            BindingContext = viewModel;
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            viewModel.ChangePassword();
        }
    }
}