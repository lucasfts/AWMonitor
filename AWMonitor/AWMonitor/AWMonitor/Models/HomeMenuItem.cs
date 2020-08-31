using System;
using System.Collections.Generic;
using System.Text;

namespace AWMonitor.Models
{
    public enum MenuItemType
    {
        Dashboard,
        Settings,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
