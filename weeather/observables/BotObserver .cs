using weather.Entities;
using weeather.Entities;

namespace weather.Observables
{
    internal class BotObserver : IObserver
    {

        private Bot _bot;

        public BotObserver(Bot bot)
        {
            _bot = bot;
        }

        public void TriggerBot(WeatherData weatherData)
        {
            if (_bot.Enabled)
            {
                if (_bot.IsBotActivated(weatherData.Temperature, weatherData.Humidity))
                {
                    _bot.PrintMessage();
                }
            }
        }

    }
}
