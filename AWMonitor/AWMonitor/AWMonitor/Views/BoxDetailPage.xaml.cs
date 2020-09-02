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
    public partial class BoxDetailPage : ContentPage
    {
        BoxDetailViewModel viewModel;

        public BoxDetailPage(BoxDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public BoxDetailPage()
        {
            InitializeComponent();

            var box = new QualityBox
            {
                Name = ""
            };

            viewModel = new BoxDetailViewModel(box);
            BindingContext = viewModel;
        }
    }
}