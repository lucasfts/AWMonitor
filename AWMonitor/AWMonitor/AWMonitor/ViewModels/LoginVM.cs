﻿using AWMonitor.Models;
using AWMonitor.Services;
using AWMonitor.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AWMonitor.ViewModels
{
    public class LoginVM : BaseViewModel
    {
        private readonly UserService _userService;

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

        public LoginVM()
        {
            User = new User();
            _userService = new UserService();
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

                    user = new User() { Phone = phone, Password = password };
                    bool isLoggedIn = await _userService.Login(this.user);

                    if (isLoggedIn)
                        App.Current.MainPage = new MainPage();
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
