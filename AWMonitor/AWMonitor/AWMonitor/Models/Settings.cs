using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWMonitor.Models
{
    public class Settings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Port { get; set; }
    }
}
