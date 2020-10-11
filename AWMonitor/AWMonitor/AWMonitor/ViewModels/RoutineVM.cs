using AWMonitor.Models;
using AWMonitor.Services;
using AWMonitor.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AWMonitor.ViewModels
{
    public class RoutineVM : BaseViewModel
    {
        private IRoutineService _routineService => DependencyService.Get<IRoutineService>();
        public ObservableCollection<Routine> Routines { get; set; }
        public Command LoadRoutinesCommand { get; set; }

        public RoutineVM()
        {
            Title = "Rotinas";

            Routines = new ObservableCollection<Routine>();
            LoadRoutinesCommand = new Command(async () => await ExecuteLoadRoutinesCommand());

            MessagingCenter.Subscribe<NewRoutinePage, Routine>(this, "AddItem", async (obj, item) =>
            {
                var result = await _routineService.AddItemAsync(item);
                if (result)
                    Routines.Add(item);
                else
                    await App.Current.MainPage.DisplayAlert("Erro", "Erro ao adicionar rotina", "Ok");
            });

            MessagingCenter.Subscribe<RoutineDetailPage, Routine>(this, "DeleteItem", async (obj, item) =>
            {
                var result = await _routineService.DeleteItemAsync(item.Id);
                if (result)
                {
                    Routines.Remove(item);
                }
            });

        }

        async Task ExecuteLoadRoutinesCommand()
        {
            IsBusy = true;

            try
            {
                Routines.Clear();
                var items = await _routineService.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Routines.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
