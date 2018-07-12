using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMapTest.Models
{
    public class WeatherData
    {
        public List<Weather> Weather { get; set; }
        public MainWeatherData MainWeatherData { get; set; }
        public Wind Wind { get; set; }
    }
}
