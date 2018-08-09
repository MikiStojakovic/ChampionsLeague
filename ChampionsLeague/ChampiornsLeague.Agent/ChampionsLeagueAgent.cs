using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChampionsLeague.Common.Abstract;
using ChampionsLeague.Common.Models;

namespace ChampiornsLeague.Agent
{
    public class ChampionsLeagueAgent : ILeagueAgent, IDisposable
    {
        private IDisposable _webApp;

        public void Start(Func<IDisposable> startWebApp)
        {
            _webApp = startWebApp();
        }

        public virtual void Dispose()
        {
            
        }

        public void ProcessGameResults(IEnumerable<GameResult> gameResults)
        {
            throw new NotImplementedException();
        }
    }
}
