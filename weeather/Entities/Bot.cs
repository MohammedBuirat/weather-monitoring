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

        public bool IsBotActivated(decimal temperature, decimal humidity)
        {
            bool valid = false;
            if (Condition.Type == ConditionType.Temperature)
            {
                valid = TriggerCondition(temperature);
            }
            else if (Condition.Type == ConditionType.Humidity)
            {
                valid = TriggerCondition(humidity);
            }
            return valid;
        }

        private bool TriggerCondition(decimal value)
        {
            bool isMoreThanThreshold = ConditionAboveTheThreshhold && (value > Condition.Threshold);
            bool lessThanThreshold = !ConditionAboveTheThreshhold && (value < Condition.Threshold);
            return isMoreThanThreshold || lessThanThreshold;
        }

        public void PrintMessage()
        {
            Console.WriteLine($"{Name} activated!");
            Console.WriteLine($"{Name}:\" {Message} \"");
        }

        public override string ToString()
        {
            return $"Bot name: {Name}   enabled: {Enabled}  message: {Message}  {Condition.ToString()}";
        }
    }
}
