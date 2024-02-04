using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace application.Converters
{
    /// <summary>
    /// Конвертер значений для преобразования булевого значения в видимость
    /// </summary>
    public class InverseBooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Преобразует булевое значение в видимость
        /// </summary>
        /// <param name="value">Булевое значение</param>
        /// <param name="targetType">Тип целевого свойства </param>
        /// <param name="parameter">Параметр конвертера</param>
        /// <param name="culture">Используемая культура </param>
        /// <returns>Видимость в зависимости от значения булевого параметра</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? Visibility.Collapsed : Visibility.Visible;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
