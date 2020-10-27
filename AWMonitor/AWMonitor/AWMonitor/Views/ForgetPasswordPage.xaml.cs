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
    public partial class ForgetPasswordPage : ContentPage
    {
        ForgetPasswordVM viewModel;

        public ForgetPasswordPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ForgetPasswordVM();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            viewModel.GetCodeAndRedirect();
        }
    }
}