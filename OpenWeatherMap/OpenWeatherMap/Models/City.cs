using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMap.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coordinates Coord { get; set; }
        public string Country { get; set; }

        public class Coordinates
        {
            public float Lon { get; set; }
            public float Lat { get; set; }
        }
    }
}
