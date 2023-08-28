using System.Xml.Serialization;
using weeather.Entities;

namespace weather.ReadData
{  
            
    internal class ParseXMLWeatherData : WeatherDataType
    {
        public WeatherData GetWeatherData(string xmlData)
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