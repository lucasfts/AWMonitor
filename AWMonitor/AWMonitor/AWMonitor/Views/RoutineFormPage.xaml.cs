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
    public partial class RoutineFormPage : ContentPage
    {
        public RoutineFormVM viewModel { get; set; }

        public RoutineFormPage(Routine routine)
        {
            InitializeComponent();

            viewModel = new RoutineFormVM(routine);

            BindingContext = viewModel;
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                Routine routine = viewModel.ToRoutineModel();

                if (routine.IsValid() && btnSave.IsEnabled)
                {
                    btnSave.IsEnabled = false;


                    if (string.IsNullOrEmpty(viewModel.Id))
                    {
                        await viewModel.AddItem(routine);
                    }
                    else
                    {
                        await viewModel.EditItem(routine);
                    }

                }
                else
                {
                    await DisplayAlert("Erro", "Preencha todos os campos para salvar a rotina", "Ok");
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

        

    }
}