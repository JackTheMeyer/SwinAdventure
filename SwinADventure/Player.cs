using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private Location _location = null;


        public Player(string name, string desc) :
            base(new string[] { "me", "inventory"}, name, desc)
        {

        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id) == true)
            {
                return this;
            }
            else if (_inventory.HasItem(id) == true)
            {
                return _inventory.Fetch(id);
            }
            else if (_location != null && _location.Name == id)
            {
                    return _location;
            }
            else if (_location != null && _location.Area.HasItem(id))
            {
                return _location.Area.Fetch(id);
            }
            return null;
        }

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
        public override string FullDescription
        {
            get
            {
                string allItems = "";
                foreach (string s in _inventory.ItemList)
                {
                    allItems += s;
                }
                return "You Are Carrying: " + allItems;
            }
        }
    }
}
