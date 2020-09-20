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
    public partial class NewRoutinePage : ContentPage
    {
        public NewRoutineVM viewModel { get; set; }

        public NewRoutinePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new NewRoutineVM();
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            Routine routine = GetRoutineModel();

            MessagingCenter.Send(this, "AddItem", routine);
            await Navigation.PopModalAsync();
        }

        private Routine GetRoutineModel()
        {
            return new Routine()
            {
                Sensor = viewModel.Sensor,
                Actuator = viewModel.Actuator,
                Action = viewModel.Action,
                Condition = viewModel.Condition,
                ConditionValue = viewModel.ConditionValue,
                Enabled = viewModel.Enabled,
                Notify = viewModel.Notify
            };
        }

    }
}