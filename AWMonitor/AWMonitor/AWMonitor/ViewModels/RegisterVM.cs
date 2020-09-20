using AWMonitor.Models;
using AWMonitor.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AWMonitor.ViewModels
{
    public class RegisterVM
    {
        private User user;

        public event PropertyChangedEventHandler PropertyChanged;

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
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
                bool canLogin = await User.Register(this.user);

                if (canLogin)
                    await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                else
                    await App.Current.MainPage.DisplayAlert("Erro", "Erro ao criar usuário", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
