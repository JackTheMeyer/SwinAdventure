using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Location : GameObject
    {
        private Inventory _area = new Inventory();
        

        public Location(string[] identifiers, string name, string description) :
            base(identifiers, name, description)
        {
            
        }

        public Inventory Area
        {
            get
            {
                return _area;
            }
        }
        
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            foreach (string s in Area.ItemList)
            {
                if (id == s)
                {
                    Area.Fetch(id);
                }
            }

            return null;
        }
        public override string FullDescription
        {
            get
            {
                string search = "\nYou look around " + Name + " and can see : ";
                foreach (string s in _area.ItemList)
                {
                    search += ("\n" + s + " " + Description);
                }

                return search;
            }
        }

    }
}
