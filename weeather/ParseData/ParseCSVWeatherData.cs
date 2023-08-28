using weeather.Entities;

namespace weather.ReadData
{
    internal class ParseCSVWeatherData : WeatherDataType
    {

        public WeatherData GetWeatherData(string csvData)
        {
            WeatherData weatherData = new WeatherData();
            weatherData = (StringRowToWeatherData(csvData));
            return weatherData;
        }

        public WeatherData StringRowToWeatherData(string dataRow)
        {
            string[] splitted = dataRow.Split(',');
            if (splitted.Count() != 3)
            {
                Console.WriteLine("improper Input format ");
            }
            string Location = splitted[0];
            decimal temperature = decimal.Parse(splitted[1]);
            decimal humidity = decimal.Parse(splitted[2]);
            WeatherData weatherData = new WeatherData(Location, temperature, humidity);
            return weatherData;
        }

    }
}