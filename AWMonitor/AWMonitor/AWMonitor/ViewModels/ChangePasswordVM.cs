using AWMonitor.Models;
using AWMonitor.Services;
using AWMonitor.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AWMonitor.ViewModels
{
    public class ChangePasswordVM : BaseViewModel
    {
        private IUserService _userService => DependencyService.Get<IUserService>();

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                if (value == null || value.Length <= 11)
                {
                    SetProperty(ref phone, value);
                }
            }
        }

        private int changePasswordCode;
        public int ChangePasswordCode
        {
            get { return changePasswordCode; }
            set { SetProperty(ref changePasswordCode, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (value == null || value.Length <= 8)
                {
                    SetProperty(ref password, value);
                }
            }
        }

        public async void ChangePassword()
        {
            try
            {
                var isPasswordEmpty = string.IsNullOrEmpty(password?.Trim());

                if (!isPasswordEmpty)
                {
                    IsBusy = true;

                    var registerResult = await _userService.ChangePassword(phone, changePasswordCode, password);

                    if (registerResult.Result)
                    {
                        await App.Current.MainPage.DisplayAlert("Parabéns", "Senha alterada com sucesso!", "Ok");
                        await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Erro", registerResult.ErrorMessage, "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
