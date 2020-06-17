using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace PhoneBookManager.Converters
{
    class PhoneNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var _number= string.Join(string.Empty, Regex.Matches(value as string , @"\d+").OfType<Match>().Select(m => m.Value));
                switch (_number.Length)
                {
                    case 7:
                        return Regex.Replace(_number, @"(\d{3})(\d{2})(\d{2})", "$1-$2-$3");
                    case 10:
                        return Regex.Replace(_number, @"(\d{3})(\d{3})(\d{2})(\d{2})", "($1) $2-$3-$4");
                    case 11:
                        return Regex.Replace(_number, @"(\d{1})(\d{3})(\d{3})(\d{2})(\d{2})", "$1-($2)-$3-$4-$5");
                    case 13:
                        return Regex.Replace(_number, @"(\d{3})(\d{3})(\d{3})(\d{2})(\d{2})", "$1-($2)-$3-$4-$5");
                    case 12:
                        return Regex.Replace(_number, @"(\d{1})(\d{1})(\d{3})(\d{3})(\d{2})(\d{2})", "$1-$2-($3)-$4-$5-$5");
                    default:
                        return _number;
                }
            }
            return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var _number = string.Join(string.Empty, Regex.Matches(value as string, @"\d+").OfType<Match>().Select(m => m.Value));
            return _number;
        }
    }
}
