using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;
using Morabaraba_9001.GameCode;

namespace Morabaraba_9001.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void PlayersStartAndCanPlace7Cows()
        {
            var player1 = new Player(Player.Type.Red, 7);
            // Note we used 7 to test if this works in testing with a smaller herd
            Assert.That(player1.CowsLeftToPlace == 7);
        }
    }
}
