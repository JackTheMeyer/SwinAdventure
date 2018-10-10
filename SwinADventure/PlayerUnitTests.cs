using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SwinAdventure
{
    class PlayerUnitTests
    {
        SwinAdventure.Item item1 = new SwinAdventure.Item(new string[] { "Shovel", "Spade" }, "Shovel", "Used for digging");
        Player Jack = new Player("The Player", "The Avatar of Jack");
        Player Who = new Player("The Player", "The Avatar of Jack");

        [TestCase]
        public void TestPlayerIs()
        {
            Assert.IsTrue(Who.AreYou("ME"));
            Assert.IsTrue(Who.AreYou("INVENTORY"));
        }

        [TestCase]
        public void TestPlayerLocatesItems()
        {
            Jack.Inventory.Put(item1);
            Assert.IsTrue(Jack.Inventory.HasItem(item1.Name));
            Assert.IsTrue(Jack.Locate(item1.Name) == item1);

        }

        [TestCase]
        public void TestPlayerLocatesIteself()
        {
            Assert.IsTrue(Who.Locate("Me") == Who);
            Assert.IsTrue(Who.Locate("Inventory") == Who);
        }

        [TestCase]
        public void TestPlayerLocatesNothing()
        {
            Assert.IsTrue(Who.Locate("Fake Item") == null);
        }

        [TestCase]
        public void TestPlayerFullDescription()
        {
            String shtDescs = "";
            foreach (String s in Jack.Inventory.ItemList)
            {
                shtDescs += s;
            }
            Assert.IsTrue(Jack.FullDescription == ("You Are Carrying: " + shtDescs));
        }
    }
}