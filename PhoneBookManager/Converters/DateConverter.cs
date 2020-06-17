using System;
using System.Globalization;
using System.Windows.Data;

namespace PhoneBookManager.Converters
{
    class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                return date;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return ((DateTime)value).ToShortDateString();
            }
            return null;
        }
    }
}
