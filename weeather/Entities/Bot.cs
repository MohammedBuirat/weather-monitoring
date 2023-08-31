using weeather.Entities;

namespace weather.Entities
{
    internal class Bot
    {

        public string Name { get; set; }
        public Condition Condition { get; set; }
        public string Message { get; set; }
        public bool Enabled { get; set; }
        bool ConditionAboveTheThreshhold { get; set; }

        public Bot(string botName, Condition condition, string message, bool enabled, bool conditionAboveTheThreshhold)
        {
            Name = botName;
            Condition = condition;
            Message = message;
            Enabled = enabled;
            ConditionAboveTheThreshhold = conditionAboveTheThreshhold;
        }

        public bool IsBotActivated(WeatherData weatherData)
        {
            if (!Enabled)
            {
                return false;
            }
            bool valid = false;
            if (Condition.Type == ConditionType.Temperature)
            {
                valid = TriggerCondition(weatherData.Temperature);
            }
            else if (Condition.Type == ConditionType.Humidity)
            {
                valid = TriggerCondition(weatherData.Humidity);
            }
            return valid;
        }

        private bool TriggerCondition(decimal value)
        {
            bool isMoreThanThreshold = ConditionAboveTheThreshhold && (value > Condition.Threshold);
            bool lessThanThreshold = !ConditionAboveTheThreshhold && (value < Condition.Threshold);
            return isMoreThanThreshold || lessThanThreshold;
        }



        public override string ToString()
        {
            return $"Bot name: {Name}   enabled: {Enabled}  message: {Message}  {Condition.ToString()}";
        }

    }
}
