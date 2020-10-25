using AWMonitor.Models;
using AWMonitor.Services;
using AWMonitor.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AWMonitor.ViewModels
{
    public class CreateSettingsVM : BaseViewModel
    {
        private ISettingsService _settingsService => DependencyService.Get<ISettingsService>();
        private IQrScanningService _qrService => DependencyService.Get<IQrScanningService>();


        private string url;
        private string port;

        public string Url { get => url; set => SetProperty(ref url, value); }
        public string Port { get => port; set => SetProperty(ref port, value); }

        public CreateSettingsVM()
        {
        }

        public async void CreateAndContinue()
        {
            try
            {
                if (string.IsNullOrEmpty(Url) || string.IsNullOrEmpty(Port))
                {
                    await App.Current.MainPage.DisplayAlert("Erro", "Preencha os campos para continuar", "Ok");
                }
                else
                {
                    var serverStatus = await _settingsService.GetServerStatus(Url, Port);
                    if (serverStatus == "active")
                    {
                        var settings = new Settings { Url = Url, Port = Port };
                        var settingsCreated = await _settingsService.AddItemAsync(settings);

                        if (settingsCreated)
                        {
                            await App.Current.MainPage.DisplayAlert("Parabéns", "Ambiente configurado com sucesso ", "Ok");
                            App.Current.MainPage = new MainPage();
                        }
                        else
                            await App.Current.MainPage.DisplayAlert("Erro", "Erro ao salvar as configurações", "Ok");
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Erro", "Servidor inválido ou indisponível", "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public async Task ReadQrCode()
        {
            try
            {
                var result = await _qrService.ScanAsync();
                await Task.Delay(100);
                if (result != null)
                {
                    var resultArray = result.Split(':');
                    Url = $"{resultArray[0]}:{resultArray[1]}";
                    Port = resultArray[2];
                }

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }
}
