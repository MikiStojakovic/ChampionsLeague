using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChampionsLeague.Common.Abstract;
using ChampionsLeague.Common.Models;

namespace ChampionsLeague.Controllers
{
    public class GameResultController : ApiController
    {
        private ILeagueAgent _agent;

        public GameResultController(ILeagueAgent agent)
        {
            _agent = agent;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]IEnumerable<GameResult> gameResults)
        {
            try
            {
                var result = _agent.ProcessGameResults(gameResults);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}