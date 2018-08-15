using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChampionsLeague.Common.Abstract;
using ChampionsLeague.Common.Models;
using ChampiornsLeague.Agent.Abstract;
using ChampiornsLeague.Agent.Converters;

namespace ChampiornsLeague.Agent
{
    public class ChampionsLeagueAgent : ILeagueAgent, IDisposable
    {
        private IDisposable _webApp;
        public IDictionary<string, TableOrder> LeagueResults { get; set; }

        public ChampionsLeagueAgent()
        {
            LeagueResults = new Dictionary<string, TableOrder>();
        }

        public void Start(Func<IDisposable> startWebApp)
        {
            _webApp = startWebApp();
        }

        public virtual void Dispose()
        {
            
        }

        public int AddGameResults(IEnumerable<GameResult> gameResults)
        {
            IsTableAddedAlready(gameResults).
                ConvertAllResults().
                AddResultsToLeagueResults(LeagueResults)
                ;

            var r = LeagueResults.Select(kvp => kvp.Value.TableRowCollection).SelectMultiLayerCollection();
            
            var r1 = r.Count();
            
            //var r1 = r.Count();

            return r1;
        }

        public int ProcessGameResults(IEnumerable<GameResult> gameResults)
        {
            return AddGameResults(gameResults);
        }

        

        private IEnumerable<GameResult> IsTableAddedAlready(IEnumerable<GameResult> gameResults)
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
