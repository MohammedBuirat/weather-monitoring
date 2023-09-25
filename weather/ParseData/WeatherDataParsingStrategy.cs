using weeather.Entities;

namespace weather.ReadData
{
    public interface WeatherDataParsingStrategy
    {
        WeatherData ParseWeatherDataFromDataString(string data);

    }
}
