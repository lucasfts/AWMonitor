using AWMonitor.Extensions;
using AWMonitor.Services;
using AWMonitor.Views;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AWMonitor.ViewModels
{
    public class ForgetPasswordVM : BaseViewModel
    {
        private IUserService _userService => DependencyService.Get<IUserService>();

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                SetProperty(ref phone, value);
            }
        }


        public async void GetCodeAndRedirect()
        {
            try
            {
                phone = phone.GetDigits();
                var code = await _userService.GetChangePasswordCode(phone);
                CrossLocalNotifications.Current.Show("AWMonitor - Alterar Senha", code.ToString());
                await App.Current.MainPage.Navigation.PushAsync(new ChangePasswordPage(phone, code));

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Não consta registro para o telefone informado.", "Ok");
            }
        }

    }
}
