using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AWMonitor.Services;
using AWMonitor.Views;
using SQLite;
using System.IO;
using Xamarin.Essentials;

namespace AWMonitor
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            RegisterServices();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private static void RegisterServices()
        {
            DependencyService.Register<RoutineService>();
            DependencyService.Register<SettingsService>();
            DependencyService.Register<UserService>();
        }
    }
}
