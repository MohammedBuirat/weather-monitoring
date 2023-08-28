
namespace weeather.Entities
{
    public class WeatherData
    {
        public string Location { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        
        public WeatherData() { }

        public WeatherData(string location,  decimal temperature, decimal humidity)
        {
            Location = location;
            Temperature = temperature;
            Humidity = humidity;
        }

        public override string ToString()
        {
            return $"{Location}     Temperature:{Temperature}   Humidity:{Humidity}";
        }

    }
}
