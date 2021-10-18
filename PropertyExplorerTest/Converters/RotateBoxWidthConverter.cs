using PropertyExplorerTest.Models.PropertyModels;
using PropertyExplorerTest.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PropertyExplorerTest.Converters
{
    public class RotateBoxWidthConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            if (targetType != typeof(double))
            {
                throw new ArgumentException("RotateBoxConverter can only be used to convert double."); // developer error
            }

            foreach (var item in values)
            {
                if (item.GetType() == typeof(double))
                {
                    //throw new ArgumentException("RotateBoxConverter can only be used to convert double."); // developer error
                }
                else if(item.GetType() == typeof(DoublePropertySet))
                {

                }
                else
                {
                    Debug.WriteLine($"{item} is {item.GetType()}");
                }
            }

            return RotationMath.GetWidth((double)values[0], (double)values[1], (double)values[2]);
            //return RotationMath.GetWidth(((DoublePropertySet)values[0]).Value, ((DoublePropertySet)values[0]).Value, ((DoublePropertySet)values[0]).Value);
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
