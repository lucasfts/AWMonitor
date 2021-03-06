﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AWMonitor.Models
{
    public enum MenuItemType
    {
        Dashboard,
        History,
        Routine,
        Settings,
        About
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
