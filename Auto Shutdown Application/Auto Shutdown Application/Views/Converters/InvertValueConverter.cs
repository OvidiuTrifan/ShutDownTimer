using System;
using System.Globalization;
using System.Windows.Data;

namespace AutoShutdownApplication.Views.Converters
{
    class InvertValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return false;
            bool boolean = value is bool && (bool) value;
            return !boolean;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
