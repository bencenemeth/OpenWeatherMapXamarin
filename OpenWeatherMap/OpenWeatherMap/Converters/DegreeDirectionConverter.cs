using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace OpenWeatherMap.Converters
{
    /// <summary>
    /// Converting wind direction degrees to actual directions
    /// </summary>
    public class DegreeDirectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float degree = (float)value;
            switch (degree)
            {
                case float deg when deg >= 11.25 && deg < 33.75:
                    return "NNE";
                case float deg when deg >= 33.75 && deg < 56.25:
                    return "NE";
                case float deg when deg >= 56.25 && deg < 78.75:
                    return "ENE";
                case float deg when deg >= 78.75 && deg < 101.25:
                    return "E";
                case float deg when deg >= 101.25 && deg < 123.75:
                    return "ESE";
                case float deg when deg >= 123.75 && deg < 146.25:
                    return "SE";
                case float deg when deg >= 146.25 && deg < 168.75:
                    return "SSE";
                case float deg when deg >= 168.75 && deg < 191.25:
                    return "S";
                case float deg when deg >= 191.25 && deg < 213.75:
                    return "SSW";
                case float deg when deg >= 213.75 && deg < 236.25:
                    return "SW";
                case float deg when deg >= 236.25 && deg < 258.75:
                    return "WSW";
                case float deg when deg >= 258.75 && deg < 281.25:
                    return "W";
                case float deg when deg >= 281.25 && deg < 303.75:
                    return "WNW";
                case float deg when deg >= 303.75 && deg < 326.25:
                    return "NW";
                case float deg when deg >= 326.25 && deg < 348.75:
                    return "NNW";
                case float deg when (deg >= 348.75 && deg < 360) || (deg >= 0 && deg < 11.25):
                    return "N";
                default:
                    return "?";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
