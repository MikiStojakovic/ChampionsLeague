using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Common.Models
{
    public class CompetitorResult
    {
        public string GroupName { get; set; }
        public string Team { get; set; }
        public bool GamesWon { get; set; }
        public bool GamesDrawn{ get; set; }
        public bool GamesLost { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
    }
}
