using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using weeather.Entities;

namespace weather.ReadData
{
    internal class ParseJSONWeatherData : WeatherDataType
    {
        public List<WeatherData> GetWeatherData(string jsonString)
        {
            List<WeatherData> personList = JsonSerializer.Deserialize<List<WeatherData>>(jsonString);
            throw new NotImplementedException();
        }
    }
}
