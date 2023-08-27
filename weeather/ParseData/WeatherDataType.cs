using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weeather.Entities;

namespace weather.ReadData
{
    internal interface WeatherDataType
    {
        List<WeatherData> GetWeatherData(string data);
    }
}
