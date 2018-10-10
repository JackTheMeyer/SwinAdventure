using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure
{
    class InventoryUnitTests
    {
        Item item1 = new Item(new string[] { "Shovel", "Spade" }, "Shovel", "Used for digging");
        Player Jack = new Player( "The Player", "The Avatar of Jack");

        [TestCase]
        public void TestFindItem()
        {
            if (Jack.Inventory.HasItem(item1.Name) == false)
            {
                Jack.Inventory.Put(item1);
            }
            Assert.IsTrue(Jack.Inventory.HasItem(item1.Name));
        }

        [TestCase]
        public void NoItemFind()
        {
            Assert.IsFalse(Jack.Inventory.HasItem("FakeItem"));
        }

        [TestCase]
        public void TestFetchItem()
        {
            Jack.Inventory.Put(item1);
            Assert.IsTrue(Jack.Inventory.Fetch(item1.Name) == item1);
        }

        [TestCase]
        public void TestTakeItem()
        {
            Assert.IsTrue(Jack.Inventory.HasItem(item1.Name));
            Jack.Inventory.Take(item1.Name);
            Jack.Inventory.Take(item1.Name);
            Assert.IsFalse(Jack.Inventory.HasItem(item1.Name));
        }

        [TestCase]
        public void TestItemList()
        {
            foreach (string s in Jack.Inventory.ItemList)
            {
                Assert.IsTrue(s == (item1.Name + "\n\t" + item1.ShortDescription + "\n"));
            }
        }
    }
}
