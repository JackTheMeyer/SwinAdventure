using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure
{
    class ItemUnitTests
    {
        SwinAdventure.Item item1 = new SwinAdventure.Item(new string[] { "Shovel", "Spade" }, "Shovel", "Used for digging");
        Player Jack = new Player("The Player", "The Avatar of Jack");
        [TestCase]
        public void TestItemIs()
        {
            Assert.IsTrue(item1.AreYou("Shovel"));
            Assert.IsTrue(item1.AreYou("Spade"));
        }

        [TestCase]
        public void TestShortDescription()
        {
            Assert.IsTrue(item1.ShortDescription == "Shovel(Shovel)");
        }

        [TestCase]
        public void TestFullDescription()
        {
            Assert.IsTrue(item1.FullDescription == "Used for digging");
        }

    }
}