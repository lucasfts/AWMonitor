﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AWMonitor.Models;
using AWMonitor.Services;

namespace AWMonitor.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            //MenuPages.Add((int)MenuItemType.History, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Dashboard:
                        MenuPages.Add(id, new NavigationPage(new DashboardPage()));
                        break;
                    case (int)MenuItemType.History:
                        MenuPages.Add(id, new NavigationPage(new HistoryPage()));
                        break;
                    case (int)MenuItemType.Routine:
                        MenuPages.Add(id, new NavigationPage(new RoutinesPage()));
                        break;
                    case (int)MenuItemType.Settings:
                        var settings = await new SettingsService().GetFirstOrDefaultAsync();
                        MenuPages.Add(id, new NavigationPage(new SettingsPage(settings)));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}