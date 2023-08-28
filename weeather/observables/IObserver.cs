using weeather.Entities;

namespace weather.Observables
{
    internal interface IObserver
    {
        void TriggerBot(WeatherData weatherData);
    }
}
