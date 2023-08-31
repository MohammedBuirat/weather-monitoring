using System.Text.Json;
using weeather.Entities;

namespace weather.ReadData
{
    internal class ParseJSONWeatherData : WeatherDataParsingStrategy
    {
        public WeatherData ParseWeatherDataFromDataString(string jsonString)
        {
            WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(jsonString);
            return weatherData;
        }

    }
}
