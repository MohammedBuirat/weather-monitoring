using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weather.Entities;
using weeather.Entities;

namespace weather.Observables
{
    internal class BotManager : IObservable
    {
        private List<IObserver> _observers = new List<IObserver>();
        public List<Bot> Bots { get; } = new List<Bot>();
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(IObserver observer,WeatherData weatherData)
        {
            foreach(var bot in _observers)
            {
                bot.TriggerBot(weatherData);
            }
        }
    }
}
