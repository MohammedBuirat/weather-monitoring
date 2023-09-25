using AutoFixture;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weather.ReadData;
using FluentAssertions;
using weeather.Entities;

namespace weather.Tests.ParsingTests
{
    public class ProcesssorTests
    {

        [Fact]
        public void ProcessorShouldRegectEmptyStrings()
        {
            WeatherDataParsingStrategy parsingStrategy = new ParseXMLWeatherData();
            string data = "";

            Action action = () => parsingStrategy.ParseWeatherDataFromDataString(data);

            action.Should().Throw<Exception>(because: "Excepting a valid Data string");
        }

        [Fact]
        public void ProcessorShouldRegectNullWeatherDataValues()
        {
            WeatherDataParsingStrategy parsingStrategy = new ParseXMLWeatherData();
            string data = $"<WeatherData>\r\n  <Location>City</Location>\r\n  <Temperature>20</Temperature>\r\n  " +
                $"<Humidity></Humidity>\r\n</WeatherData>";
            Action action = () => parsingStrategy.ParseWeatherDataFromDataString(data);
            action.Should().Throw<Exception>();
        }
    }
}
