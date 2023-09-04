using System.Net.Http.Headers;
using weather.Entities;
using FluentAssertions;
using AutoFixture;
using weeather.Entities;
using AutoFixture.Xunit2;

namespace weather.Tests
{
    public class BotShould
    {

        [Fact]
        public void BotShouldBeActivated()
        {
            var fixture = new Fixture();
            Bot bot = fixture.Build<Bot>().Create();

            bot.Threshold = 10;
            bot.ConditionAboveTheThreshhold = true;
            bot.TypeOfCondition = ConditionType.Temperature;

            WeatherData weatherData = new WeatherData(
                "RAMALLAH",
                20,
                60);
            bot.IsBotActivated(weatherData).Should().BeTrue();
        }

        [Fact]
        public void BotShouldNotBeActivatedWhenNotEnabled()
        {
            var fixture = new Fixture();
            Bot bot = fixture.Build<Bot>().With(b => b.Enabled, false).Create();
            WeatherData weatherData = fixture.Create<WeatherData>();
            bot.IsBotActivated(weatherData).Should().BeFalse(because: "A bot that is not enabled should not be activated");
        }

        [Theory]
        [AutoData]
        public void BotShouldBeActivatedWhenValueMoreThanThresholdTemprature(decimal threshold)
        {
            var fixture = new Fixture();
            Bot bot = fixture.Build<Bot>().Create();
            bot.Threshold = threshold;
            bot.Enabled = true;
            bot.ConditionAboveTheThreshhold = true;
            bot.TypeOfCondition = ConditionType.Temperature;

            WeatherData weather = fixture.Build<WeatherData>().With(w => w.Temperature, 20).
                With(w => w.Humidity, 20).Create<WeatherData>();

            bot.IsBotActivated(weather).Should().Be(threshold < weather.Temperature );
        }

        [Theory]
        [AutoData]
        public void BotShouldBeActivatedWhenValueMoreThanThresholdHumaidity(decimal threshold)
        {
            var fixture = new Fixture();
            Bot bot = fixture.Build<Bot>().Create();
            bot.Threshold = threshold;
            bot.Enabled = true;
            bot.ConditionAboveTheThreshhold = true;
            bot.TypeOfCondition = ConditionType.Humidity;

            WeatherData weather = fixture.Build<WeatherData>().With(w => w.Temperature, 20).
                With(w => w.Humidity, 20).Create<WeatherData>();

            bot.IsBotActivated(weather).Should().Be(threshold < weather.Humidity);
        }

    }
}