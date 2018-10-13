using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace SwinAdventure
{
    class PathUnitTests
    {
        // Create Player
        Player P1 = new Player("Jack", "Dat Boi");

        // Create Locations
        Location Camp = new Location(new string[] { "Home", "Camp", "Base" }, "Camp", "Where all my stuff is");
        Location Forrest = new Location(new string[] { "Forrest", "Woods", "Thicket" }, "Forrest", "A Spooky Forrest");

        // Creaet Paths
        //Path CampToForrest = new Path(new string[] { "north" }, "south", "a barely visible track to the north, leading off into the night", Camp, Forrest);
       // Path ForrestToCamp = new Path(new string[] { "south" }, "south", "a barely visible track to the south, leading bac into the darkness...", Forrest, Camp);


        [TestCase]
        public void TestMovePlayer()
        {
            // Add Paths to Locations
            //Camp.AddPath(CampToForrest);
            //Forrest.AddPath(ForrestToCamp);
            P1.Location = Camp;
            P1.Location.PlayerVisits(P1);
        }

    }
}
