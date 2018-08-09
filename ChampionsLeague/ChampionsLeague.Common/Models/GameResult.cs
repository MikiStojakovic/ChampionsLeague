using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionsLeague.Common.Models
{
    public class GameResult
    {
        public string LeagueTitle { get; set; }
        public int MatchDay { get; set; }
        public string Group { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime KickOfAt { get; set; }
        public string Score { get; set; }
    }
}