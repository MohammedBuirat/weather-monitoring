using weeather.Entities;

namespace weather.ReadData
{
    internal class ParseData
    {
        public WeatherData ParseDataToWeatherList(string data)
        {
            WeatherDataProcessor processor = ParsingStrategyPicker(data);
            return processor.ParseDataToWeatherDataList(data);
        }

        WeatherDataProcessor ParsingStrategyPicker(string data)
        {
            WeatherDataProcessor processor;
            WeatherDataType dataType;
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