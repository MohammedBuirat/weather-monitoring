using weeather.Entities;

namespace weather.Entities
{
    internal class Bot
    {

        public string Name { get; set; }
        public string Message { get; set; }
        public bool Enabled { get; set; }
        bool ConditionAboveTheThreshhold { get; set; }
        public ConditionType TypeOfCondition { get; set; }
        public decimal Threshold { get; set; }

        public Bot(string name, string message, bool enabled, bool conditionAboveTheThreshhold, ConditionType typeOfCondition, decimal threshold)
        {
            Name = name;
            Message = message;
            Enabled = enabled;
            ConditionAboveTheThreshhold = conditionAboveTheThreshhold;
            TypeOfCondition = typeOfCondition;
            Threshold = threshold;
        }

        public bool IsBotActivated(WeatherData weatherData)
        {
            if (!Enabled)
            {
                return false;
            }
            bool valid = false;
            if (TypeOfCondition == ConditionType.Temperature)
            {
                valid = TriggerCondition(weatherData.Temperature);
            }
            else if (TypeOfCondition == ConditionType.Humidity)
            {
                valid = TriggerCondition(weatherData.Humidity);
            }
            return valid;
        }

        private bool TriggerCondition(decimal value)
        {
            bool isMoreThanThreshold = ConditionAboveTheThreshhold && (value > Threshold);
            bool lessThanThreshold = !ConditionAboveTheThreshhold && (value < Threshold);
            return isMoreThanThreshold || lessThanThreshold;
        }



        public override string ToString()
        {
            return $"Bot name: {Name}   enabled: {Enabled}  message: {Message}  {TypeOfCondition.ToString()}    {Threshold}";
        }

    }
}
