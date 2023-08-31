using weeather.Entities;

namespace weather.ReadData
{
    internal class WeatherDataProcessor
    {

        private WeatherDataParsingStrategy _dataType;

        public WeatherDataProcessor(WeatherDataParsingStrategy dataSource)
        {
            _dataType = dataSource;
        }

        public WeatherData ParseDataToWeatherData(string data)
        {
            return _dataType.ParseWeatherDataFromDataString(data);
        }

    }
}
