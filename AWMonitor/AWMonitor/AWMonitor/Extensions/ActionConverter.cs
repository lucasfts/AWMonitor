using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AWMonitor.Extensions
{
    public class ActionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            return (value as string).Replace("On", "Ligar").Replace("Off", "Desligar");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            return (value as string).Replace("Ligar", "On").Replace("Desligar", "Off");
        }
    }
}
