using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChampionsLeague.Common.Abstract;
using ChampionsLeague.Common.Models;
using ChampiornsLeague.Agent.Abstract;

namespace ChampiornsLeague.Agent
{
    public class ChampionsLeagueAgent : ILeagueAgent, IDisposable
    {
        private IDisposable _webApp;
        public IDictionary<string, TableOrder> LeagueResults { get; set; }
        private IConvertable _resultConverter { get; set; }

        public ChampionsLeagueAgent(IConvertable resultConverter)
        {

        }

        public void Start(Func<IDisposable> startWebApp)
        {
            _webApp = startWebApp();
        }

        public virtual void Dispose()
        {
            
        }

        public bool AddGameResults(IEnumerable<GameResult> gameResults)
        {
            IsTableAdded(gameResults)
                .All();

            return true;
        }

        public bool ProcessGameResults(IEnumerable<GameResult> gameResults)
        {
            return true;
        }

        private IEnumerable<GameResult> IsTableAdded(IEnumerable<GameResult> gameResults)
        {
            gameResults
                .Select(gr => gr.Group)
                .Where(groupName => LeagueResults.ContainsKey(groupName) == false)
                .ToList()
                .ForEach(groupToAdd => LeagueResults.Add(groupToAdd, new TableOrder()));

            return gameResults;
        }
    }
}
