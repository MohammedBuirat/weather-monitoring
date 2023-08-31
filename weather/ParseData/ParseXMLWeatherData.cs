using System.Xml.Serialization;
using weeather.Entities;

namespace weather.ReadData
{  
            
    internal class ParseXMLWeatherData : WeatherDataParsingStrategy
    {

        public WeatherData ParseWeatherDataFromDataString(string xmlData)
        {
            WeatherData weather;
            XmlSerializer serializer = new XmlSerializer(typeof(WeatherData));

            using (TextReader reader = new StringReader(xmlData))
            {
                weather = (WeatherData)serializer.Deserialize(reader);
            }

            return weather;
        }

    }
}