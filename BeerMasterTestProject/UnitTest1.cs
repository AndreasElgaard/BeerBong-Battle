using System;
using System.Threading.Tasks;
using Java.Lang.Reflect;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;
using TodoREST;
using TodoREST.Models;
using TodoREST.Views;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BeerMasterTestProject
{
    [TestFixture]
    public class BeerMasterTest
    {
        [Test]
        public void TestOpretBruger()
        {
            var OpretbrugerModel = new OpretBruger();

            OpretbrugerModel.password1_ = "testpass";
            OpretbrugerModel.password2_ = "testpass";

            bool isValid = OpretbrugerModel.PasswordCheck();

            Assert.IsTrue(isValid);
        }

        [Test]
        public async Task TestRestCallToLeaderboard()
        {
            var rest = new RestService();
            Game gamet = new Game();

            gamet = await rest.CreateGame(gamet);

            Assert.AreEqual(gamet, App.game);



        }
        
    }
}
