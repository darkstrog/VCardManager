using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace PhoneBookManager.Converters
{
    class ArrayStringToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    var result = String.Join(", ", value as IEnumerable<string>);

                    return result;
                }
            }
            catch { }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return new List<string>((value as string).Split(", "));
            }
            throw new NotImplementedException();
        }
    }
}
