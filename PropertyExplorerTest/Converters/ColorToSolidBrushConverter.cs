using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace PropertyExplorerTest.Converters
{
    public class ColorToSolidBrushConverter : IValueConverter
    {
        /// <summary>
        /// Color 값을 이용하여, SolidColorBrush로 변환
        /// BaseModel 필드에 Color를 String으로 받고 #FF001122 이렇게
        /// 받아서 써야지 Model을 나중에 쉽게 DB로 밀어넣을 수 있을 것 같다.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)value;
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brush = value as SolidColorBrush;
            return brush?.Color;
        }
    }
}
