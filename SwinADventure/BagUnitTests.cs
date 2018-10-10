using System;
using SwinAdventure;
using NUnit.Framework;

namespace SwinAdventure
{
    class BagUnitTests
    {
        Bag b1 = new Bag(new string[] { "b1", "Bag1" }, "Bag1", "The First Bag");
        Bag b2 = new Bag(new string[] { "b2", "Bag2" }, "Bag2", "The Second Bag");

        Item Shovel = new Item(new string[] { "Shovel", "Spade" }, "Shovel", "Used for digging");
        Item Sword = new SwinAdventure.Item(new string[] { "Sword", "Blade" }, "Sword", "A sharp steel blade");
        Item Hat = new Item(new string[] { "Hat" }, "Hat", "Protects from sun damage");

        [TestCase]
        public void TestBagLocatesItems()
        {
            b1.Inventory.Put(Shovel);

            Assert.IsTrue(b1.Locate("Shovel") == Shovel);

        }

        [TestCase]
        public void TestBagLocatesItself()
        {
            Assert.IsTrue(b1.Locate("b1") == b1);
        }

        [TestCase]
        public void TestBagLocatesNothing()
        {
            Assert.IsTrue(b1.Locate("FakeItem") == null);
        }

        [TestCase]
        public void TestBagFullDescription()
        {
            String fullDesc = "In the " + b1.Name + " you can see: \n";
            foreach (String s in b1.Inventory.ItemList)
            {
                fullDesc += s;
            }
            Assert.IsTrue(b1.FullDescription == fullDesc);
        }

        [TestCase]
        public void TestBagInBag()
        {
            b1.Inventory.Put(b2);
            b1.Inventory.Put(Shovel);
            b2.Inventory.Put(Hat);
            Assert.IsTrue(b1.Locate("Bag2") == b2);
            Assert.IsTrue(b1.Locate("Shovel") == Shovel);
            Assert.IsTrue(b1.Locate("Hat") == null);
            Assert.IsTrue(b2.Locate("Hat") == Hat);
        }
    }
}
