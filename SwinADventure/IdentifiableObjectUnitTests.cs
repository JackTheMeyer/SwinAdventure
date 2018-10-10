using System;
using SwinAdventure;
using NUnit.Framework;

namespace SwinAdventure
{
    [TestFixture]
    public class IdentifiableObjectTest
    {

        IdentifiableObject iden = new SwinAdventure.IdentifiableObject(new string[] { "id1", "id2" });


        [TestCase]
        public void TestAreYou()
        {

            Assert.IsTrue(iden.AreYou("id1"));
        }

        [TestCase]
        public void TestNotAreYou()
        {
            Assert.IsFalse(iden.AreYou("Frediccus"));
        }

        [TestCase]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(iden.AreYou("ID2"));
        }

        [TestCase]
        public void TestFirstId()
        {
            Assert.IsNotNull(iden.FirstId);
        }

        [TestCase]
        public void AddIdentifier()
        {
            iden.AddIdentifier("id4");
            Assert.IsTrue(iden.AreYou("id4"));
        }
    }
}
