using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PropertyExplorerTest.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
			try
			{
				var flag = false;
				if (value is bool)
				{
					flag = (bool)value;
				}

				if (parameter != null)
				{
					bool inverted;
					if (bool.TryParse(parameter.ToString(), out inverted))
					{
						inverted = inverted == false;
						flag = flag == inverted;
					}
				}

				return flag ? Visibility.Visible : Visibility.Collapsed;
			}
			catch (Exception ex)
			{
				// need logging.
				return Visibility.Collapsed;
			}
		}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
			try
			{
				var target = (Visibility)value;
				var result = target == Visibility.Visible;

				if (parameter != null)
				{
					bool inverted;
					if (bool.TryParse(parameter.ToString(), out inverted))
					{
						inverted = inverted == false;
						result = result == inverted;
					}
				}

				return result;
			}
			catch
			{
				return false;
			}
		}
    }
}
