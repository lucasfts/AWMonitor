using System;
using System.Collections.Generic;
using System.Text;

namespace AWMonitor.Models
{
    public enum MenuItemType
    {
        Boxes,
        History,
        Settings,
        About,
        Routine
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
