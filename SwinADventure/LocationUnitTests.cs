using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace SwinAdventure
{
    class LocationUnitTests
    {
        Location Camp = new Location(new string[] { "Home", "Camp", "Base" }, "Camp", "Where all my stuff is");
        Player P1 = new Player("Jack", "The Man");

        Item Campfire = new Item(new string[] { "Campfire" }, "Campfire", "A warm campfire to cook food on");
        Item Tent = new Item(new string[] { "Tent" }, "Tent", "Where I sleep");
        Item Bucket = new Item(new string[] { "Bucket" }, "Bucket", "Can be filled with things");


        [TestCase]
        public void TestLocationIs()
        {
            P1.Location = Camp;
            Assert.AreEqual(P1.Locate("Camp"), Camp);
            Assert.AreEqual(Camp.Locate("Camp"), Camp);
            
        }

        [TestCase]
        public void TestLocationHasItem()
        {
            Camp.Area.Put(Campfire);

            P1.Location = Camp;

            Assert.IsTrue(Camp.Area.HasItem(Campfire.Name));
        }

        [TestCase]
        public void TestPlaterFindItemInLocation()
        {
            P1.Location = Camp;
            Camp.Area.Put(Campfire);
            Assert.IsTrue(P1.Locate("Campfire") == Campfire);
        }
    }
}
