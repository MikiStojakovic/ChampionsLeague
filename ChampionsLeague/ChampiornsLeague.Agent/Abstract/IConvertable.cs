using ChampionsLeague.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampiornsLeague.Agent.Abstract
{
    public interface IConvertable
    {
        IEnumerable<CompetitorResult> All(IEnumerable<GameResult> gameResults);
    }
}
