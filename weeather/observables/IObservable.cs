using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weeather.Entities;

namespace weather.Observables
{
    internal interface IObservable
    {
        public void Attach(IObserver observer);
        public void Detach(IObserver observer);
        public void Notify(IObserver observer, WeatherData weatherData);
    }
}
