using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weeather.Entities;

namespace weather.Observables
{
    internal interface IObserver
    {
        void TriggerBots(WeatherData weatherData);
    }
}
