using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weeather.Entities;

namespace weather.ReadData
{
    internal class WeatherDataProcessor
    {
        private WeatherDataType _dataType;

        public WeatherDataProcessor(WeatherDataType dataSource)
        {
            _dataType = dataSource;
        }

        public List<WeatherData> ParseDataToWeatherDataList(string data)
        {
            return _dataType.GetWeatherData(data);
        }

    }
}
