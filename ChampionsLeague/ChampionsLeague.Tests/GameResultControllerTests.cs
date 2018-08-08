using System;
using ChampionsLeague.Controllers;
using ChampionsLeague.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChampionsLeague.Tests
{
    [TestClass]
    public class GameResultControllerTests
    {
        [TestMethod]
        public void PutTestAddOneGameResult()
        {
            //-- Arange
            var gameResult = new GameResult();
            gameResult.LeagueTitle = "Champions league 2016 / 17";
            gameResult.MatchDay = 1;
            gameResult.Group = "A";
            gameResult.HomeTeam = "PSG";
            gameResult.AwayTeam = "Arsenal";
            gameResult.KickOfAt = DateTime
                .ParseExact("13-09-2017 20:45:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            gameResult.Score = "1:1";

            var controller = new GameResultController();

            //-- Act
            var actual = controller.Put(new Guid(), gameResult);

            //-- Assert
            Assert.AreEqual(null, actual);
        }
    }
}
