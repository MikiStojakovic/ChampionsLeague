using ChampionsLeague.Common.Models;
using ChampiornsLeague.Agent.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampiornsLeague.Agent.Converters
{
    public static class CompetitorResultComparer
    {
        public static int PointsCalculator(int currentResultTeam, int awayResultTeam)
        {
            if (currentResultTeam == awayResultTeam) return 1;

            return currentResultTeam > awayResultTeam ? 3 : 0;
        }
    }

    class GameToCompetitorResultConverter : IConvertable
    {
        public IEnumerable<CompetitorResult> All(IEnumerable<GameResult> gameResults)
        {
            gameResults
                .Select(gr =>
                    new
                    {
                        Group = gr.Group,
                        HomeTeam = gr.HomeTeam,
                        HomeTeamGoals = gr.Score.Split(":".ToCharArray()).FirstOrDefault(),
                        AwayTeam = gr.AwayTeam,
                        AwayTeamGoals = gr.Score.Split(":".ToCharArray()).LastOrDefault()
                    })
                    .Select(er => new Tuple<CompetitorResult, CompetitorResult>(
                            new CompetitorResult { },
                            new CompetitorResult { }
                        ));

            return null;
        }

        static IEnumerable<GameResult> All<GameResult>(this IEnumerable<GameResult> data)
        {
            return data;
        }
    }
}
