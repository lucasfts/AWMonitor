using AWMonitor.Models;
using AWMonitor.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AWMonitor.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
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

        public LoginVM()
        {
            User = new User();
        }

        public async void Login()
        {
            bool canLogin = await User.Login(this.user);

            if (canLogin)
                await App.Current.MainPage.Navigation.PushAsync(new MainPage());
            else
                await App.Current.MainPage.DisplayAlert("Erro", "Telefone e/ou PIN inválidos", "Ok");
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
