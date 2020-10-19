using AWMonitor.Models;
using AWMonitor.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AWMonitor.ViewModels
{
    public class SettingsVM : BaseViewModel
    {
        private ISettingsService _settingsService => DependencyService.Get<ISettingsService>();
        private IQrScanningService _qrService => DependencyService.Get<IQrScanningService>();

        private string url;
        private string port;

        public string Url { get => url; set => SetProperty(ref url, value); }
        public string Port { get => port; set => SetProperty(ref port, value); }

        public async Task ReadQrCode()
        {
            try
            {
                var result = await _qrService.ScanAsync();
                await Task.Delay(100);
                if (result != null)
                {
                    var resultArray = result.Split(':');
                    Url = resultArray[0] + resultArray[1];
                    Port = resultArray[2];
                }

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public async void LoadCurrentSettings()
        {
            try
            {
                var settings = await _settingsService.GetFirstOrDefaultAsync();
                Url = settings.Url;
                Port = settings.Port;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public async Task Save()
        {
            try
            {
                if (string.IsNullOrEmpty(Url) || string.IsNullOrEmpty(Port))
                {
                    await App.Current.MainPage.DisplayAlert("Erro", "Preencha os campos para salvar", "Ok");
                }
                else
                {
                    var settings = await _settingsService.GetFirstOrDefaultAsync();
                    settings.Url = Url;
                    settings.Port = Port;
                    await _settingsService.UpdateItemAsync(settings);
                    await App.Current.MainPage.DisplayAlert("Sucesso", "Configurações atualizadas com sucesso", "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }
}
