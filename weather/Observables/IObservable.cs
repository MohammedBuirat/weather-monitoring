using weeather.Entities;

namespace weather.Observables
{
    public interface IObservable
    {

        public void Attach(IObserver observer);
        public void Detach(IObserver observer);
        public void Notify(WeatherData weatherData);

    }
}
