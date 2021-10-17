using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PropertyExplorerTest.Converters
{
    public class SizeToHalfConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if((value.GetType() != typeof(double)))
            {
                throw new ArgumentException("SizeToHalfConverter can only be used to convert double.");
            }

            if (targetType != typeof(double))
            {
                throw new ArgumentException("SizeToHalfConverter can only be used to convert double."); // developer error
            }

            if ((double)value != 0)
                value = (double)value / 2;

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
