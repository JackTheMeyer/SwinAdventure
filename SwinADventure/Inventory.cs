using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public Inventory()
        {

        }

        public List<string> ItemList
        {
            get
            {
                List<string> _itmList = new List<string>();
                foreach (Item i in _items)
                {
                    _itmList.Add(i.Name + "\n\t" + i.ShortDescription + "\n");
                }
                return _itmList;
            }
        }

        public bool HasItem(string id)
        {
            foreach (Item i in _items)
            {
                if (id == i.Name)
                {
                    return true;
                }
            }

            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            foreach (Item i in _items)
            {
                if (id == i.Name)
                {
                    _items.Remove(i);
                    return i;
                }
            }

            return null;
        }

        public Item Fetch(string id)
        {
            foreach (Item i in _items)
            {
                if (id.ToLower() == i.Name.ToLower())
                {
                    return i;
                }
            }

            return null;
        }


    }
}
