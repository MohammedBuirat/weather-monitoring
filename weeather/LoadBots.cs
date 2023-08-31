using System.Text.Json;
using weather.Entities;

namespace weather
{
    internal class LoadBots
    {

        public List<Bot> LoadBotsFromConfigFile()
        {
            string data = LoadConfigFileData();
            return ParseStringToBots(data);
        }

        private string LoadConfigFileData()
        {
            string fileData = File.ReadAllText("../../../config.json");
            return fileData;
        }

        //here i had to do it like this since i will not be able to pass the bot in 
        //bitConfiguration to a new method which caused me to preform all the work in a single method
        private List<Bot> ParseStringToBots(string data)
        {
            List<Bot> bots = new List<Bot>();
            var botConfigurations = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(data);
            foreach (var bot in botConfigurations)
            {
                string name = bot.Key;
                var botProperties = bot.Value;
                decimal threshold;
                ConditionType conditionType;
                if (botProperties.TryGetProperty("humidityThreshold", out var humidityThreshold))
                {
                    threshold = humidityThreshold.GetDecimal();
                    conditionType = ConditionType.Humidity;
                }
                else
                {
                    threshold = botProperties.GetProperty("temperatureThreshold").GetDecimal();
                    conditionType = ConditionType.Temperature;
                }
                Condition condition = new Condition(conditionType, threshold);
                bool enabled = botProperties.GetProperty("enabled").GetBoolean();
                bool conditionAboveTheThreshold = botProperties.GetProperty("conditionAboveTheThreshold").GetBoolean();
                string message = botProperties.GetProperty("message").GetString();
                Bot newBot = new Bot(name, condition, message, enabled, conditionAboveTheThreshold);
                bots.Add(newBot);
            }
            return bots;
        }

    }
}