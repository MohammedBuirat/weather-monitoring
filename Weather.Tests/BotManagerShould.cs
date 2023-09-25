using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using weather.Observables;
using weather.Entities;
using FluentAssertions;

namespace weather.Tests
{
    public class BotManagerShould
    {

        public BotManager GetBotManager()
        {
            var fixture = new Fixture();
            BotManager botManager = new BotManager();
            for (int i = 0; i < 4; i++)
            {
                Bot bot = fixture.Build<Bot>().Create();
                botManager.Bots.Add(bot);
                botManager.Attach(new BotObserver(bot));
            }
            return botManager;
        }

    }
}