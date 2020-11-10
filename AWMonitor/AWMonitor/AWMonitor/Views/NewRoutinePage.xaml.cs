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

        protected async override void OnAppearing()
        {
            await viewModel.LoadActuators();
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                Routine routine = GetRoutineModel();

                if (routine.IsValid() && btnSave.IsEnabled)
                {
                    btnSave.IsEnabled = false;

                    MessagingCenter.Send(this, "AddItem", routine);
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Erro", "Preencha todos os campos para criar a rotina", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
            }
            finally
            {
                btnSave.IsEnabled = true;
            }
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