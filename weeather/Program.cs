using weather;
using weather.Entities;
using weather.Observables;
using weather.ReadData;
using weeather.Entities;

namespace weeather
{
    internal class Program
    {

        static BotManager botManager = new BotManager();
        static void Main(string[] args)
        {
            GetBots();
            EntryPoint();
        }

        static void GetBots()
        {
            LoadBots loadBots = new LoadBots();
            List<Bot> bots = loadBots.LoadBotsFromConfigFile();
            foreach (var bot in bots)
            {
                botManager.Bots.Add(bot);
                botManager.Attach(new BotObserver(bot));
            }
        }

        static void EntryPoint()
        {
            while (true)
            {
                Console.WriteLine("Please enter the path of the file containing the data or enter exit to exit");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("No elements where entered");
                }
                else if (input == "exit")
                {
                    return;
                }
                else
                {
                    NotifyBotsUsingFileData(fileName: input);
                }
            }
        }

        static void NotifyBotsUsingFileData(string fileName)
        {
            try
            {
                string data = File.ReadAllText(fileName);
                ParseData parseData = new ParseData();
                WeatherData weatherData = parseData.ParseDataToWeatherList(data);
                botManager.Notify(weatherData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}