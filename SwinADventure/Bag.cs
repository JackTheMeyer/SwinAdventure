using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        Inventory _inventory = new Inventory();
        String[] _identifiers;
        String _name;
        String _description;


        public Bag(String[] ids, String name, String desc) :
            base(ids, name, desc)
        {
            _identifiers = ids;
            _name = name;
            _description = desc;
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public GameObject Locate(String id)
        {
            foreach (String s in _identifiers)
            {
                if (s == id)
                {
                    return this;
                }
            }
            return _inventory.Fetch(id);
        }

        public new String FullDescription
        {
            get
            {
                String fullDesc = "In the " + Name + " you can see: \n";
                foreach (String s in Inventory.ItemList)
                {
                    fullDesc += s;
                }

                return fullDesc;
            }

        }

    }
}
