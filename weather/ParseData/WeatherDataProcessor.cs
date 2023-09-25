using weeather.Entities;

namespace weather.ReadData
{
    public class WeatherDataProcessor
    {

        private WeatherDataParsingStrategy _Parsingtrategy;

        public WeatherDataProcessor(WeatherDataParsingStrategy dataParsingStrategy)
        {
            _Parsingtrategy = dataParsingStrategy;
        }

        public WeatherData ParseDataToWeatherData(string data)
        {
            CheckForEmptyStrings(data);
            WeatherData weatherData = _Parsingtrategy.ParseWeatherDataFromDataString(data);
            CheckForEmptyFilds(weatherData);
            return weatherData;
        }

        private void CheckForEmptyStrings(string data)
        {
            if(data == "" || data == null)
            {
                throw new ArgumentException("Data to be parsed is empty!");
            }
        }

        private void CheckForEmptyFilds(WeatherData weatherData)
        {
            if(weatherData == null)
            {
                throw new ArgumentNullException();
            }
            if (weatherData.Location.Equals(""))
            {
                throw new ArgumentNullException("Location field is empty!");
            }
            if (weatherData.Humidity == null || weatherData.Temperature == null || weatherData.Location == null )
            {
                throw new ArgumentNullException("One or more fields in WeatherData are null!");
            }
        }

    }
}
