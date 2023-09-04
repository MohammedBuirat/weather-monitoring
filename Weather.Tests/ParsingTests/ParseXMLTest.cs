using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using weather.ReadData;
using weeather.Entities;

namespace weather.Tests.ParsingTests
{
    public class ParseXMLTest
    {

        [Theory]
        [AutoData]
        public void TestValidXMLParsing(decimal temperature, decimal humidity, string location)
        {
            var parsingStrategy = new ParseXMLWeatherData();
            string data = $"<WeatherData>\r\n  <Location>{location}</Location>\r\n  <Temperature>{temperature}</Temperature>\r\n  " +
                $"<Humidity>{humidity}</Humidity>\r\n</WeatherData>";

            WeatherData weatherData = parsingStrategy.ParseWeatherDataFromDataString(data);
            bool areEqual = weatherData.Temperature == temperature && weatherData.Humidity == humidity
                && weatherData.Location == location;
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void WrongDataFormatShouldThrowEception()
        {
            var parsingStrategy = new ParseXMLWeatherData();
            string data = "\r\n{\r\n  \"Location\": \"City Name\",\r\n  \"Temperature\": 23.0,\r\n  \"Humidity\": 85.0\r\n}";
            Action action = () => parsingStrategy.ParseWeatherDataFromDataString(data);
            action.Should().Throw<Exception>();
        }

        [Theory]
        [AutoData]
        public void WrongDataTypeShouldThrowException(string temperature, string humidity, decimal location)
        {
            WeatherDataParsingStrategy parsingStrategy = new ParseXMLWeatherData();
            string data = $"<WeatherData>\r\n  <Location>{location}</Location>\r\n  <Temperature>{temperature}</Temperature>\r\n  " +
                $"<Humidity>{humidity}</Humidity>\r\n</WeatherData>";

            Action action = () => parsingStrategy.ParseWeatherDataFromDataString(data);

            action.Should().Throw<Exception>(because: "Excepting a valid XML data");
        }

        [Theory]
        [AutoData]
        public void EmptyLoactionStringInXMLData(decimal temperature, decimal humidity, string location)
        {
            location = "";
            WeatherDataParsingStrategy parsingStrategy = new ParseXMLWeatherData();
            string data = $"<WeatherData>\r\n  <Location>{location}</Location>\r\n  <Temperature>{temperature}</Temperature>\r\n  " +
                $"<Humidity>{humidity}</Humidity>\r\n</WeatherData>";

            Action action = () => parsingStrategy.ParseWeatherDataFromDataString(data);

            action.Should().NotThrow<Exception>();
        }
    }
}
