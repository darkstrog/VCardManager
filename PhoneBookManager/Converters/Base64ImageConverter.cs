using MixERP.Net.VCards.Models;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhoneBookManager.Converters
{
    class Base64ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((Photo)value)?.Contents is string _value)
            {
                try
                {
                    var _pattern = @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([?=\/\w \.-]*)\/?$";
                    bool mm = Regex.IsMatch(_value, _pattern, RegexOptions.None, TimeSpan.FromMilliseconds(10));

                    if (!File.Exists(_value) & !mm)
                    {
                        //если строка не URL и не файл на диске то пробуем ее читать как Base64, если URL возвращаем в Image
                        return System.Convert.FromBase64String(((Photo)value).Contents as string);
                    }
                    //если строка оказалась файлом возращаем путь
                    else
                    {
                        return ((Photo)value).Contents as string;
                    }
                }
                catch (Exception)
                {
                    return "/Res/no_image150.png";
                }
            }
            return "/Res/no_image150.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        
    }
}
