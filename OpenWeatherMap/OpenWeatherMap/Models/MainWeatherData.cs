using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMapTest.Models
{
    public class MainWeatherData
    {
        public float Temp { get; set; }
        public float Pressure { get; set; }
        public float Humidity { get; set; }
        public float TempMin { get; set; }
        public float TempMax { get; set; }
    }
}
