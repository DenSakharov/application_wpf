using System;
using System.Globalization;
using System.Windows.Data;

namespace application.Converters
{
    public class LoadingTextConverter : IMultiValueConverter
    {
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
