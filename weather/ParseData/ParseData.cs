﻿using weeather.Entities;

namespace weather.ReadData
{
    internal class ParseData
    {
        public WeatherData ParseDataToWeather(string data)
        {
            WeatherDataProcessor processor = PickParsingStrategy(data);
            return processor.ParseDataToWeatherData(data);
        }

        WeatherDataProcessor PickParsingStrategy(string data)
        {
            WeatherDataProcessor processor;
            WeatherDataParsingStrategy dataType;
            if (IsXml(data))
            {
                dataType = new ParseXMLWeatherData();
            }
            else if (IsJson(data))
            {
                dataType = new ParseJSONWeatherData();
            }
            else if (IsCsv(data))
            {
                dataType = new ParseCSVWeatherData();
            }
            else
            {
                Console.WriteLine("data format is not avalible");
                return null;
            }
            return processor = new WeatherDataProcessor(dataType);
        }

        private bool IsXml(string data)
        {
            return data[0] == '<';
        }

        private bool IsJson(string data)
        {
            return data[0] == '{';
        }

        private bool IsCsv(string data)
        {
            return char.IsLetter(data[0]);
        }
    }
}