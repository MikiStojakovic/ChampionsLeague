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

    public static class GameToCompetitorResultConverter 
        //: IConvertable
    {
        public static void AddResultsToLeagueResults(this IEnumerable<CompetitorResult> competitorResults, IDictionary<string, TableOrder> leagueResults)
        {
            competitorResults
                .ToList()
                .ForEach(cr => leagueResults[cr.GroupName].AddCompetiotorResult(cr));
        }

        public static IEnumerable<CompetitorResult> ConvertAllResults<T>(this IEnumerable<T> gameResults)
        {
            return gameResults
             .Select(gr => gr as GameResult)
             .Select(gr => new
             {
                 Group = gr.Group,
                 HomeTeam = gr.HomeTeam,
                 HomeTeamScoredGoals = Int32.Parse(gr.Score.Split(":".ToCharArray()).FirstOrDefault()),
                 AwayTeam = gr.AwayTeam,
                 AwayTeamScoredGoals = Int32.Parse(gr.Score.Split(":".ToCharArray()).LastOrDefault())
             })
            .Select(extRes => new List<CompetitorResult>()
            {
                                    new CompetitorResult()
                                    {
                                        GroupName = extRes.Group,
                                        Team = extRes.HomeTeam,
                                        GamesWon = CheckCondition(new Func<bool>(() => extRes.HomeTeamScoredGoals > extRes.AwayTeamScoredGoals ? true : false)),
                                        GamesDrawn = CheckCondition(new Func<bool>(() => extRes.HomeTeamScoredGoals == extRes.AwayTeamScoredGoals ? true : false)),
                                        GamesLost = CheckCondition(new Func<bool>(() => extRes.HomeTeamScoredGoals < extRes.AwayTeamScoredGoals ? true : false)),
                                        GoalsScored = extRes.HomeTeamScoredGoals,
                                        GoalsAgainst = extRes.AwayTeamScoredGoals,
                                        GoalDifference = extRes.HomeTeamScoredGoals - extRes.AwayTeamScoredGoals,
                                        Points = CalculatePoints(new Func<bool>(() => extRes.HomeTeamScoredGoals > extRes.AwayTeamScoredGoals ? true : false),
                                                                           new Func<bool>(() => extRes.HomeTeamScoredGoals == extRes.AwayTeamScoredGoals ? true : false))
                                    },
                                     new CompetitorResult()
                                     {
                                         GroupName = extRes.Group,
                                         Team = extRes.AwayTeam,
                                         GamesWon = CheckCondition(new Func<bool>(() => extRes.AwayTeamScoredGoals > extRes.HomeTeamScoredGoals ? true : false)),
                                         GamesDrawn = CheckCondition(new Func<bool>(() => extRes.AwayTeamScoredGoals == extRes.HomeTeamScoredGoals ? true : false)),
                                         GamesLost = CheckCondition(new Func<bool>(() => extRes.AwayTeamScoredGoals < extRes.HomeTeamScoredGoals ? true : false)),
                                         GoalsScored = extRes.AwayTeamScoredGoals,
                                         GoalsAgainst = extRes.HomeTeamScoredGoals,
                                         GoalDifference = extRes.AwayTeamScoredGoals - extRes.HomeTeamScoredGoals,
                                         Points = CalculatePoints(new Func<bool>(() => extRes.AwayTeamScoredGoals > extRes.HomeTeamScoredGoals ? true : false),
                                               new Func<bool>(() => extRes.AwayTeamScoredGoals == extRes.HomeTeamScoredGoals ? true : false))
                                     }
                                     }
                                )
                                .SelectMultiLayerCollection();
        }

        public static List<CompetitorResult> SelectMultiLayerCollection(this IEnumerable<IEnumerable<CompetitorResult>> nestedCollections)
        {
            var retVal = new List<CompetitorResult>();

            foreach (var collection in nestedCollections)
            {
                collection.ToList().ForEach(el => retVal.Add(el));
            }

            return retVal;
        }

        private static bool CheckCondition(Func<bool> condition)
        {
                return condition();
        }

        private static int  CalculatePoints(Func<bool> isGameWon, Func<bool> isGameDrawn)
        {
            return isGameWon() ? 3 : isGameDrawn() ? 1 : 0;
        }
    }
}
