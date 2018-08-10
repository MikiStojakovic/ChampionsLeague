using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Common.Models
{
    public class TableOrder
    {
        public string GroupName { get; set; }
        public IList<CompetitorResult> TableRowCollection { get; set; }

        public void AddCompetiotorResult(CompetitorResult competitorResult)
        {
            this.TableRowCollection.Add(competitorResult);
        }
    }
}
