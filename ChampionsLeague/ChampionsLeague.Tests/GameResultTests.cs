using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ChampionsLeague.Controllers;
using ChampionsLeague.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Net.WebRequestMethods;

namespace ChampionsLeague.Tests
{
    [TestClass]
    public class GameResultTests
    {
        [TestMethod]
        public void PostTestAddNewGameResult()
        {
            //--Arrange
            var gameResult = new GameResult
            {
                LeagueTitle = "Champions league 2016/17",
                MatchDay = 1,
                Group = "A",
                HomeTeam = "PSG",
                AwayTeam = "Arsenal",
                KickOfAt = DateTime.Parse("13/09/2017 20:45:00"),
                Score = "1:1"
            };

            var controller = new GameResultController();

            //--Act
            var result = controller.Post(gameResult);

            //--Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
