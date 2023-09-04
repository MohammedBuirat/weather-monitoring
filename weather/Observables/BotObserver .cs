using System.Xml.Linq;
using weather.Entities;
using weeather.Entities;

namespace weather.Observables
{
    public class BotObserver : IObserver
    {

        private Bot _bot;

        public BotObserver(Bot bot)
        {
            _bot = bot;
        }

        public void TriggerBot(WeatherData weatherData)
        {
            if (_bot.IsBotActivated(weatherData))
            {
                NotifyBot(_bot);
            }
        }

        private void NotifyBot(Bot bot)
        {
            Console.WriteLine($"{bot.Name} activated!");
            Console.WriteLine($"{bot.Name}:\" {bot.Message} \"");
        }

    }
}
