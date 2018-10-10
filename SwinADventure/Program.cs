using System;

namespace SwinAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "placeholder";
            // Create Locations
            Location Camp = new Location(new string[] { "Home", "Camp", "Base" }, "Camp", "Where all my stuff is");

            // Create Player
            Console.WriteLine("Please Enter your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nPlease Describe yourself: ");
            string description = Console.ReadLine();
            Player P1 = new Player(name, description);

            //Put player in starting location
            P1.Location = Camp;

            // Create Starting Items
            Item Shovel = new Item(new string[] { "shovel", "spade" }, "shovel", "Used for digging");
            Item Sword = new SwinAdventure.Item(new string[] { "sword", "blade" }, "sword", "A sharp steel blade");
            Bag Satchel = new Bag(new string[] { "satchel", "bag" }, "satchel", "good for holding things");
            Item Hat = new Item(new string[] { "hat" }, "hat", "Protects from sun damage");
            Item Campfire = new Item(new string[] { "Campfire" }, "Campfire", "A warm campfire to cook food on");
            Item Tent = new Item(new string[] { "Tent" }, "Tent", "Where I sleep");
            Item Bucket = new Item(new string[] { "Bucket" }, "Bucket", "Can be filled with things");

            //Put Items in Bag
            P1.Inventory.Put(Shovel);
            P1.Inventory.Put(Sword);
            P1.Inventory.Put(Satchel);
            Satchel.Inventory.Put(Hat);

            //Put some items in the camp
            Camp.Area.Put(Campfire);
            Camp.Area.Put(Tent);
            Camp.Area.Put(Bucket);

            Console.WriteLine("\nPress Enter to Exit, or \n Enter a Look Command: ");
            command = Console.ReadLine();

            while (command != "")
            {
                string[] commands = command.Split(' ');
                LookCommand CurrentCommand = new LookCommand(commands);
                Console.WriteLine(CurrentCommand.Execute(P1, CurrentCommand.Cmd));
                Console.WriteLine("\nPress Enter to Exit, or \n Enter a Look Command: ");
                command = Console.ReadLine();
            }

        }
    }
}
