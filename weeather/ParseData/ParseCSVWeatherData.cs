using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weeather.Entities;

namespace weather.ReadData
{
    internal class ParseCSVWeatherData : WeatherDataType
    {

        public List<WeatherData> GetWeatherData(string csvData)
        {
            List<WeatherData> weatherData = new List<WeatherData>();
            string[] dataRows = ToDataRows(csvData);
            foreach (string dataRow in dataRows)
            {
                weatherData.Add(StringRowToWeatherData(dataRow));
            }
            return weatherData;
        }

        public string[] ToDataRows(string csvData)
        {
            string[] splitted = csvData.Split('\n');
            return splitted;
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