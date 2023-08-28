namespace weather.Entities
{
    internal class Condition
    {
        public ConditionType Type { get; set; }
        public decimal Threshold { get; set; }

        public Condition(ConditionType type, decimal threshold)
        {
            Type = type;
            Threshold = threshold;
        }

        public override string ToString()
        {
            return $"Condition: {Type} {Threshold}";
        }
    }
}
