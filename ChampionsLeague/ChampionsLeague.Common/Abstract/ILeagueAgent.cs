﻿using ChampionsLeague.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Common.Abstract
{
    public interface ILeagueAgent
    {
        int ProcessGameResults(IEnumerable<GameResult> gameResults);
    }
}
