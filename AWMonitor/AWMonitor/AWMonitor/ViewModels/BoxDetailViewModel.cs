using AWMonitor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWMonitor.ViewModels
{
    public class BoxDetailViewModel : BaseViewModel
    {
        public QualityBox Box { get; set; }

        public BoxDetailViewModel(QualityBox box = null)
        {
            Title = box?.Name;
            Box = box;
        }
    }
}
