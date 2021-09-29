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
		/// <summary>
		/// Convert를 호출한 지점에서 사용된 Value를
		/// 적절한 값으로 변경한 후
		/// return 값에 실어보낸다.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns>
		/// Visibility.Visible, Visibility.Collapsed 둘 중 하나가 넘어가겠지
		/// </returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
			try
			{
				//value를 boolean으로 컨버팅한 후
				//해당 조건에 따라 Visible 또는 Collapsed로 UIElement를 세팅
				var flag = false;
				if (value is bool)
				{
					flag = (bool)value;
				}

				//현재 사용 안됨.
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

		/// <summary>
		/// 컨버팅의 역순
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns>Boolean값이 넘어간다.</returns>
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
