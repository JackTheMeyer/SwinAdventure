using System;
using SwinAdventure;
using NUnit.Framework;
namespace SwinAdventure
{
    class LookCommandUnitTests
    {
        Player Jack = new Player("Jack", "The Avatar of Jack");
        Bag satchel = new Bag(new string[] { "satchel", "bag" }, "satchel", "good for holding things");
        LookCommand cmd = new LookCommand(new string[] { "Look", "at", "Me" });
        Item Gem = new Item(new string[] { "gem", "jewel" }, "gem", "Bright red Gem");
        LookCommand gemcmd = new LookCommand(new string[] { "Look", "at", "Gem" });
        LookCommand gemInMe = new LookCommand(new string[] { "Look", "at", "gem", "in", "me" });
        LookCommand gemInBag = new LookCommand(new string[] { "Look", "at", "gem", "in", "satchel" });
        LookCommand invalid1 = new LookCommand(new string[] { "Search", "at", "me" });
        LookCommand invalid2 = new LookCommand(new string[] { "Look", "around" });
        LookCommand invalid3 = new LookCommand(new string[] { "Look", "in", "me" });
        LookCommand invalid4 = new LookCommand(new string[] { "Look", "at", "gem", "at", "satchel" });

        [TestCase]
        public void TestLookAtMe()
        {
            Assert.IsTrue(cmd.Execute(Jack, cmd.Cmd) == Jack.FullDescription);
        }

        [TestCase]
        public void TestLookAtGem()
        {
            if (Jack.Inventory.HasItem(Gem.Name) == false)
            {
                Jack.Inventory.Put(Gem);
            }
            Assert.IsTrue(gemcmd.Execute(Jack, gemcmd.Cmd) == Gem.FullDescription);
        }

        [TestCase]
        public void TestLookAtUnk()
        {
            if (Jack.Inventory.HasItem(Gem.Name))
            {
                Jack.Inventory.Take(Gem.Name);
            }
            Assert.IsTrue(gemcmd.Execute(Jack, gemcmd.Cmd) == "I Can't Find The gem");
        }

        [TestCase]
        public void TestLookAtGemInMe()
        {
            if (Jack.Inventory.HasItem(Gem.Name) == false)
            {
                Jack.Inventory.Put(Gem);
            }
            Assert.IsTrue(gemInMe.Execute(Jack, gemcmd.Cmd) == Gem.FullDescription);
        }

        [TestCase]
        public void LookAtGemInBag()
        {
            if (satchel.Inventory.HasItem(Gem.Name) == false)
            {
                satchel.Inventory.Put(Gem);
            }
            if (Jack.Inventory.HasItem(satchel.Name) == false)
            {
                Jack.Inventory.Put(satchel);
            }

            Assert.IsTrue(gemInBag.Execute(Jack, gemInBag.Cmd) == Gem.FullDescription);

        }

        [TestCase]
        public void LookAtNoGemInBag()
        {
            if (satchel.Inventory.HasItem(Gem.Name))
            {
                satchel.Inventory.Take(Gem.Name);
            }
            if (Jack.Inventory.HasItem(satchel.Name) == false)
            {
                Jack.Inventory.Put(satchel);
            }
            Assert.IsTrue(gemInBag.Execute(Jack, gemInBag.Cmd) == ("I Can't Find The gem"));
        }

        public void TestInvalidLook()
        {
            Assert.IsTrue(invalid1.Execute(Jack, invalid1.Cmd) == "Error In Look Input");
            Assert.IsTrue(invalid2.Execute(Jack, invalid2.Cmd) == "I Don't Know How To Look Like That");
            Assert.IsTrue(invalid3.Execute(Jack, invalid3.Cmd) == "What Do You Want To Look At?");
            Assert.IsTrue(invalid4.Execute(Jack, invalid4.Cmd) == "What Do You Want To Look In?");
        }
    }
}
