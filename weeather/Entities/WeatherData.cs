using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weeather.Entities
{
    internal class WeatherData
    {
        public string Location { get; set; }
        public decimal Temparture { get; set; }
        public decimal Humidity { get; set; }
        
        public WeatherData() { }

        public WeatherData(string location,  decimal temparture, decimal humidity)
        {
            Location = location;
            Temparture = temparture;
            Humidity = humidity;
        }

    }
}
