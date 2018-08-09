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
        private static string hostUrl { get; set; }
        private static string publicDirectoryPath { get; set; }

        static void Main(string[] args)
        {
            Console.Title = "Champions League";

            hostUrl = ConfigurationManager.AppSettings["hostUrl"];
            publicDirectoryPath = ConfigurationManager.AppSettings["publicDirectoryPath"];
            Func<IDisposable> startWebApp = new Func<IDisposable>(StartWebAgent);

            using (var app = new ChampionsLeagueAgent())
            {
                app.Start(startWebApp);
                Console.WriteLine("Champions League Agent Started on url: \"{0}\"", hostUrl);
                
                Console.ReadKey();
            }
        }

        private static IDisposable StartWebAgent()
        {
            return ChampionsLeagueWebApp.Start(
                hostUrl: hostUrl,
                publicDirectoryPath: publicDirectoryPath);
        }
    }
}
