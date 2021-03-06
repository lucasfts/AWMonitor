﻿using AWMonitor.Models;
using AWMonitor.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AWMonitor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginVM viewModel;

        public LoginPage()
        {
            InitializeComponent();

            viewModel = new LoginVM();

            BindingContext = viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.LoadLastUserLogin();
        }

        private void Register_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void ForgetPassword_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgetPasswordPage());
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            viewModel.Login();
        }
    }
}