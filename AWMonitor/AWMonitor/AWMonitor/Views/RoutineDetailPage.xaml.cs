using AWMonitor.Models;
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
    public partial class RoutineDetailPage : ContentPage
    {
        public Routine Routine { get; set; }

        public RoutineDetailPage(Routine routine = null)
        {
            InitializeComponent();

            BindingContext = Routine = routine;
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteItem", Routine);
            await Navigation.PopAsync();
        }
    }
}