using weeather.Entities;

namespace weather.ReadData
{
    internal interface WeatherDataType
    {
        WeatherData GetWeatherData(string data);

    }
}
