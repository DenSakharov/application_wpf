using System;
using System.Globalization;
using System.Windows.Data;

namespace application.Converters
{
    /// <summary>
    /// Конвертер значений для преобразования информации о загрузке в текстовое представление
    /// </summary>
    public class LoadingTextConverter : IMultiValueConverter
    {
        /// <summary>
        /// Преобразует значения, связанные с информацией о загрузке, в текстовое представление.
        /// </summary>
        /// <param name="values">Массив значений. Первый элемент - флаг загрузки (bool), второй элемент - количество загруженных записей (int)</param>
        /// <param name="targetType">Тип целевого свойства</param>
        /// <param name="parameter">Параметр конвертера </param>
        /// <param name="culture">Используемая культура </param>
        /// <returns>Текстовое представление в зависимости от состояния загрузки и количества записей</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2 && values[0] is bool isLoading)
            {
                string loadingText = isLoading ? "Идет загрузка данных..." : $"Данные загружены. Количество записей: {values[1]}";
                return loadingText;
            }
            return "Данные загружены.";
        }
        
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
