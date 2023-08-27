using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using weeather.Entities;

namespace weather.ReadData
{
    internal class ParseXMLWeatherData : WeatherDataType
    {
        public List<WeatherData> GetWeatherData(string xmlData)
        {
            List<WeatherData> personList;
            XmlSerializer serializer = new XmlSerializer(typeof(WeatherData));

            using (TextReader reader = new StringReader(xmlData))
            {
                personList = (List<WeatherData>)serializer.Deserialize(reader);
            }
            return personList;
        }


    }
}
