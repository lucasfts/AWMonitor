using AWMonitor.Extensions;
using AWMonitor.Models;
using AWMonitor.Services;
using AWMonitor.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AWMonitor.ViewModels
{
    public class LoginVM : BaseViewModel
    {
        private IUserService _userService => DependencyService.Get<IUserService>();
        private ISettingsService _settingsService => DependencyService.Get<ISettingsService>();

        private User user;
        public User User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                SetProperty(ref phone, value);
            }
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

        public LoginVM()
        {
            User = new User();
        }

        public async void Login()
        {
            try
            {
                var isPhoneEmpty = string.IsNullOrEmpty(phone?.Trim());
                var isPasswordEmpty = string.IsNullOrEmpty(password?.Trim());

                if (!isPhoneEmpty && !isPasswordEmpty)
                {
                    IsBusy = true;

                    user = new User() { Phone = phone.GetDigits(), Password = password };
                    bool isLoggedIn = await _userService.Login(this.user);

                    if (isLoggedIn)
                    {
                        var settings = await _settingsService.GetFirstOrDefaultAsync();

                        if (settings != null)
                            App.Current.MainPage = new MainPage();
                        else
                            App.Current.MainPage = new CreateSettingsPage();
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Erro", "Telefone e/ou PIN inválidos", "Ok");
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
