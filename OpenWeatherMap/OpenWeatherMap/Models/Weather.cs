using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMapTest.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public string MainData { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
