﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWMonitor.Services
{
    public interface IQrScanningService
    {
        Task<string> ScanAsync();
    }
}
