using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AWMonitor.Extensions
{
    public static class StringExtensions
    {
        public static string GetDigits(this string text)
        {
            string justDigits = new string(text.Where(char.IsDigit).ToArray());
            return justDigits;
        }
    }
}
