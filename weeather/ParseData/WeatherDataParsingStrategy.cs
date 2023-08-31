using weeather.Entities;

namespace weather.ReadData
{
    internal interface WeatherDataParsingStrategy
    {
        WeatherData ParseWeatherDataFromDataString(string data);

    }
}
