using OpenWeatherMap.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMapTest.Models
{
    public class WeatherData
    {
        public List<Weather> Weather { get; set; }
        public MainWeatherData Main { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public Rain Rain { get; set; }
        public Sys Sys { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public long Dt { get; set; }
    }
}
