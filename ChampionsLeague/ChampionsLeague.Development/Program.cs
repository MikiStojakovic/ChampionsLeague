using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChampiornsLeague.Agent;

namespace ChampionsLeague.Development
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Champions League";

            using (var app = new ChampionsLeagueAgent())
            {
                app.Start();
            }
        }
    }
}
