using AWMonitor.Models;
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
    public partial class RoutinesPage : ContentPage
    {
        RoutineVM viewModel;

        public RoutinesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RoutineVM();

            if (viewModel.Routines.Count == 0)
                viewModel.IsBusy = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewRoutinePage()));
        }

        private async void tapItemDetail_Tapped(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Routine)layout.BindingContext;
            await Navigation.PushAsync(new RoutineDetailPage(item));
        }
    }
}