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

        public WeatherData ParseDataToWeatherDataList(string data)
        {
            return _dataType.GetWeatherData(data);
        }

    }
}
