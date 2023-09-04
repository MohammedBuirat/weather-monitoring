using weeather.Entities;

namespace weather.Observables
{
    public interface IObserver
    {

        void TriggerBot(WeatherData weatherData);

    }
}
