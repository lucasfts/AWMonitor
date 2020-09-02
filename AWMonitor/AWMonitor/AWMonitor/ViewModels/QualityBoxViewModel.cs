using AWMonitor.Models;
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
    public class QualityBoxViewModel : BaseViewModel
    {
        public ObservableCollection<QualityBox> Boxes { get; set; }
        public Command LoadBoxesCommand { get; set; }

        public QualityBoxViewModel()
        {
            Title = "Grupo de sensores";
            Boxes = new ObservableCollection<QualityBox>();
            LoadBoxesCommand = new Command(async () => await ExecuteLoadBoxesCommand());

            MessagingCenter.Subscribe<NewBoxPage, QualityBox>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as QualityBox;
                Boxes.Add(newItem);
                await BoxDataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadBoxesCommand()
        {
            IsBusy = true;

            try
            {
                Boxes.Clear();
                var items = await BoxDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Boxes.Add(item);
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
