using System.Xml.Serialization;
using weeather.Entities;

namespace weather.ReadData
{  
            
    public class ParseXMLWeatherData : WeatherDataParsingStrategy
    {

        public WeatherData ParseWeatherDataFromDataString(string xmlData)
        {
            WeatherData weather;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(WeatherData));

                using (TextReader reader = new StringReader(xmlData))
                {
                    weather = (WeatherData)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in the data format", ex);
            }
            return weather;
        }

    }
}