using System;

namespace SwinAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "placeholder";
            //create the Command Processor
            CommandProcessor Processor = new CommandProcessor();

            // Create Locations
            Location Camp = new Location(new string[] { "Home", "Camp", "Base" }, "Camp", "Where all my stuff is");
            Location Forrest = new Location(new string[] { "Forrest", "Woods", "Thicket" }, "Forrest", "A Spooky Forrest");

            // Create Pathing for Locations
            Path CampToForrest = new Path(new string[] { "north" }, "south", "a barely visible track to the north, leading off into the night", Camp, Forrest);
            Path ForrestToCamp = new Path(new string[] { "south" }, "south", "a barely visible track to the south, leading bac into the darkness...", Forrest, Camp);
            // Add Paths to Locations
            Camp.AddPath(CampToForrest);
            Forrest.AddPath(ForrestToCamp);

            // Create Player
            Console.WriteLine("Please Enter your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nPlease Describe yourself: ");
            string description = Console.ReadLine();
            Player P1 = new Player(name, description);
            Console.WriteLine(P1.Name + " begins in Camp.");

            //Put player in starting location
            P1.Location = Camp;
            P1.Location.PlayerVisits(P1);

            // Create Starting Items
            Item Shovel = new Item(new string[] { "shovel", "spade", "digger" }, "shovel", "Used for digging");
            Item Sword = new SwinAdventure.Item(new string[] { "sword", "blade", "metal-stabby-stick" }, "sword", "A sharp steel blade");
            Bag Satchel = new Bag(new string[] { "satchel", "bag", "container" }, "satchel", "good for holding things");
            Item Hat = new Item(new string[] { "hat", "cap", "sunlight shield" }, "hat", "Protects from sun damage");
            Item Campfire = new Item(new string[] { "Campfire", "fire", "burning-logs of warmth" }, "Campfire", "A warm campfire to cook food on");
            Item Tent = new Item(new string[] { "Tent", "tabernacle", "canvas" }, "Tent", "Where I sleep");
            Item Bucket = new Item(new string[] { "bucket", "pail", "cask" }, "Bucket", "Can be filled with things");
            Item Stick = new Item(new string[] { "stick", "branch", "big twig"}, "Stick", "A solid stick snapped off a tree, about the length of your forearm");
            Item Stone = new Item(new string[] { "stone", "rock", "geode" }, "Stone", "A round rigid rock, snuggly fits in the palm of your hand");

            //Put Items in Bag
            P1.Inventory.Put(Shovel);
            P1.Inventory.Put(Sword);
            P1.Inventory.Put(Satchel);
            Satchel.Inventory.Put(Hat);

            //Put some items in the camp
            Camp.Area.Put(Campfire);
            Camp.Area.Put(Tent);
            Camp.Area.Put(Bucket);

            // Put some items in the Forrest
            Forrest.Area.Put(Stick);
            Forrest.Area.Put(Stone);


            Console.WriteLine("\nPress Enter to Exit, or \n Enter a Look or Move Command: ");
            command = Console.ReadLine();

            while (command != "")
            {
                Processor.Proccess(command, P1);
                Console.WriteLine("\nPress Enter to Exit, or \n Enter a Look or Move Command: ");
                command = Console.ReadLine();
            }

        }
    }
}
