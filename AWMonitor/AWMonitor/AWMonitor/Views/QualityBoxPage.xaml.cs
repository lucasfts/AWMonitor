using AWMonitor.Models;
using AWMonitor.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AWMonitor.Views
{
    [DesignTimeVisible(false)]
    public partial class QualityBoxPage : ContentPage
    {
        QualityBoxViewModel viewModel;

        public QualityBoxPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new QualityBoxViewModel();
        }

        async void OnSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (QualityBox)layout.BindingContext;
            await Navigation.PushAsync(new BoxDetailPage(new BoxDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewBoxPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Boxes.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}