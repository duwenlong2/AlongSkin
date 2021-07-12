using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AlongSkin.Controls.Converter
{
    public class DoubleToCornerRadius : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                return new CornerRadius((double)value / System.Convert.ToDouble(parameter));
            }
            return new CornerRadius((double)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                return ((CornerRadius)value).TopLeft * System.Convert.ToDouble(parameter);
            }
            return ((CornerRadius)value).TopLeft;
        }
    }
}
