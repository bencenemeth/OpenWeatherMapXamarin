using OpenWeatherMap.Models;
using OpenWeatherMapTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMap.Models
{
    public class Forecast
    {
        public City City { get; set; }
        public int Cnt { get; set; }
        public List<WeatherData> List { get; set; }
    }
}
