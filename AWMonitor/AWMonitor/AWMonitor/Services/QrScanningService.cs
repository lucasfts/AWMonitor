using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZXing.Mobile;

namespace AWMonitor.Services
{
    public class QrScanningService : IQrScanningService
    {
        public async Task<string> ScanAsync()
        {
            var options = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Scanear o QR Code",
                BottomText = "Por favor espere",
                CancelButtonText = "Cancelar"
            };

            var scanResult = await scanner.Scan(options);
            return scanResult.Text;
        }
    }
}
