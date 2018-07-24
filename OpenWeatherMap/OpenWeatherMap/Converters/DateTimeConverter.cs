using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace OpenWeatherMap.Converters
{
    /// <summary>
    /// Converting unix utc timestamp to DateTimeOffset
    /// </summary>
    // OpenWeatherMaps API doesn't provide timezone information.
    // TODO: FIX TIMEZONE
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds((long)value);
            return dateTimeOffset.ToString("t");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
