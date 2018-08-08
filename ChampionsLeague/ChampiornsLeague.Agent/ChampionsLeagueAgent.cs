using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChampionsLeague;

namespace ChampiornsLeague.Agent
{
    public class ChampionsLeagueAgent : IDisposable
    {
        private IDisposable _webApp;

        public void Start()
        {
            var hostUrl = ConfigurationManager.AppSettings["hostUrl"];
            var publicDirectoryPath = ConfigurationManager.AppSettings["publicDirectoryPath"];

            _webApp = ChampionsLeagueWebApp.Start(
                hostUrl: hostUrl,
                publicDirectoryPath: publicDirectoryPath);
        }

        public virtual void Dispose()
        {
            
        }
    }
}
