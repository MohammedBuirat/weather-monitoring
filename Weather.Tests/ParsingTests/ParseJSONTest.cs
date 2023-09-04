using AutoFixture.Xunit2;
using AutoFixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weather.ReadData;
using weeather.Entities;

namespace weather.Tests.ParsingTests
{
    public class ParseJSONTest
    {
        [Theory]
        [AutoData]
        public void TestValidXMLParsing(decimal temperature, decimal humidity, string location)
        {
            var fixture = new Fixture();
            var parsingStrategy = new ParseJSONWeatherData();
            string data = $@"{{
            ""Location"": ""{location}"",
            ""Temperature"": {temperature:F1},
            ""Humidity"": {humidity:F1}
            }}";

            WeatherData weatherData = parsingStrategy.ParseWeatherDataFromDataString(data);
            bool areEqual = weatherData.Temperature == temperature && weatherData.Humidity == humidity
                && weatherData.Location == location;
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void WrongDataFormatShouldThrowEception()
        {
            var parsingStrategy = new ParseJSONWeatherData();
            string data = $"<WeatherData>\r\n  <Location>Ramallah</Location>\r\n  <Temperature>23.0</Temperature>\r\n  " +
                $"<Humidity>23.0</Humidity>\r\n</WeatherData>";
            Action action = () => parsingStrategy.ParseWeatherDataFromDataString(data);
            action.Should().Throw<Exception>();
        }

        [Theory]
        [AutoData]
        public void EmptyLoactionStringInXMLData(decimal temperature, decimal humidity, string location)
        {
            var fixture = new Fixture();
            location = "";
            WeatherDataParsingStrategy parsingStrategy = new ParseXMLWeatherData();
            string data = $@"{{
            ""Location"": ""{location}"",
            ""Temperature"": {temperature:F1},
            ""Humidity"": {humidity:F1}
            }}";

            Action action = () => parsingStrategy.ParseWeatherDataFromDataString(data);

            action.Should().Throw<Exception>();
        }
    }
}
