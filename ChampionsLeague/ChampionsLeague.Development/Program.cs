using System;
using System.Configuration;
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

            var hostUrl = ConfigurationManager.AppSettings["hostUrl"];

            using (var app = new ChampionsLeagueAgent())
            {
                app.Start();
                Console.WriteLine("Champions League Agent Started on url: \"{0}\"", hostUrl);
                
                Console.ReadKey();
            }
        }
    }
}
