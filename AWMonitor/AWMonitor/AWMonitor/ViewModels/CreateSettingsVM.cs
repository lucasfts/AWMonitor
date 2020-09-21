using AWMonitor.Models;
using AWMonitor.Services;
using AWMonitor.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWMonitor.ViewModels
{
    public class CreateSettingsVM : BaseViewModel
    {
        private readonly SettingsService _settingsService;

        private string url;
        private string port;

        public string Url { get => url; set => SetProperty(ref url, value); }
        public string Port { get => port; set => SetProperty(ref port, value); }

        public CreateSettingsVM()
        {
            _settingsService = new SettingsService();
        }

        public async void CreateAndContinue()
        {
            try
            {
                var settings = new Settings { Url = url, Port = port };
                var settingsCreated = await _settingsService.AddItemAsync(settings);

                if (settingsCreated)
                {
                    await App.Current.MainPage.DisplayAlert("Parabéns", "Ambiente configurado com sucesso ", "Ok");
                    App.Current.MainPage = new MainPage();
                }
                else
                    await App.Current.MainPage.DisplayAlert("Erro", "Erro ao salvar as configurações", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }
}
