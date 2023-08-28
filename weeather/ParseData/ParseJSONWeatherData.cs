using System.Text.Json;
using weeather.Entities;

namespace weather.ReadData
{
    internal class ParseJSONWeatherData : WeatherDataType
    {
        public WeatherData GetWeatherData(string jsonString)
        {
            WeatherData weather = JsonSerializer.Deserialize<WeatherData>(jsonString);
            return weather;
        }

    }
}
