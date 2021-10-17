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
    public class RotateBoxWidthMidConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double angle=0.0;
            double width=0.0;
            double height=0.0;

            if (targetType != typeof(double))
            {
                throw new ArgumentException("RotateBoxConverter can only be used to convert double."); // developer error
            }

            foreach (var item in values)
            {
                if (item.GetType() != typeof(DoublePropertySet))
                {
                    ////throw new ArgumentException("RotateBoxConverter can only be used to convert double."); // developer error
                    Debug.WriteLine($"{item} is {item.GetType()}");
                }
                else
                {
                    var temp = item as DoublePropertySet;
                    if (temp.Name == "ShapeAngle")
                    {
                        angle = temp.Value;
                    }
                    else if(temp.Name == "Width" || temp.Name == "ShapeWidth")
                    {
                        width = temp.Value;
                    }
                    else if (temp.Name == "Height" || temp.Name == "ShapeHeight")
                    {
                        height = temp.Value;
                    }
                    Debug.WriteLine($"{item} is {item.GetType()}");
                }
            }

            var ret = RotationMath.GetWidth(angle, width, height);

            return ret / 2;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
