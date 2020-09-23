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
    public class RegisterVM : BaseViewModel
    {
        private IUserService _userService => DependencyService.Get<IUserService>();

        private User user;
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

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

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (value == null || value.Length <= 4)
                {
                    SetProperty(ref password, value);
                }
            }
        }

        public RegisterVM()
        {
            User = new User();
        }

        public async void Register()
        {
            try
            {
                var isNameEmpty = string.IsNullOrEmpty(name?.Trim());
                var isPhoneEmpty = string.IsNullOrEmpty(phone?.Trim());
                var isPasswordEmpty = string.IsNullOrEmpty(password?.Trim());

                if (!isNameEmpty && !isPhoneEmpty && !isPasswordEmpty)
                {
                    IsBusy = true;

                    user = new User() { Name = name, Phone = phone, Password = password };
                    bool isRegistered = await _userService.Register(this.user);

                    if (isRegistered)
                    {
                        await App.Current.MainPage.DisplayAlert("Parabéns", "Usuário cadastrado com sucesso", "Ok");
                        await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Erro", "Erro ao criar usuário", "Ok");
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
