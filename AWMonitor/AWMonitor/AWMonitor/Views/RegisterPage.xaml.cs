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
    public partial class RegisterPage : ContentPage
    {
        RegisterVM viewModel;

        public RegisterPage()
        {
            InitializeComponent();

            viewModel = new RegisterVM();
            BindingContext = viewModel;
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            viewModel.Register();
        }
    }
}