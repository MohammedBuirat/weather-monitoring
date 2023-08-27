using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using weather.Entities;

namespace weather
{
    internal class LoadBots
    {
        public List<Bot> LoadBotsFromConfigFile()
        {
            string data = ConfigurationFileData();
            return new List<Bot>();
        }

        private string ConfigurationFileData()
        {
            string fileData = File.ReadAllText("config.json");
            return fileData;
        }

        //here i had to do it like this since i will not be able to pass the bot in 
        //bitConfiguration to a new method which caused me to preform all the work in a single method
        private List<Bot> ParseToBots(string data)
        {
            List<Bot> bots = new List<Bot>();
            var botConfigurations = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(data);
            foreach (var bot in botConfigurations)
            {
                decimal threshold;
                ConditionType conditionType;
                if (bot.Value.TryGetProperty("humidityThreshold"))
                {
                    threshold = bot.Value.TryGetProperty("humidityThreshold");
                    conditionType = ConditionType.Humidity;
                }
                else
                {
                    threshold = bot.Value.TryGetProperty("temperatureThreshold");
                    conditionType = ConditionType.Temperature;
                }
                Condition condition = new Condition(conditionType, threshold);
                bool enabled = bot.Value.TryGetProperty("enabled");
                bool conditionAboveTheThreshhold = bot.Value.TryGetProperty("conditionAboveTheThreshhold");
                string message = bot.Value.ToString("message");
                string name = bot.Key;
                Bot newBot = new Bot(name, condition, message, enabled, conditionAboveTheThreshhold);
                bots.Add(newBot);
            }
            return bots;
        }

    }
}