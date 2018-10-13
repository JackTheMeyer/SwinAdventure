using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Location : GameObject
    {
        private Inventory _area = new Inventory();
        private List<Path> _paths = new List<Path>();
        private List<Player> _visitedPlayers = new List<Player>();

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
        
        public List<Path> Paths
        {
            get
            {
                return _paths;
            }
        }

        public List<Player> PlayersVisited
        {
            get
            {
                return _visitedPlayers;
            }
 
        }

        public void PlayerVisits(Player p)
        {
            bool result = false;
            foreach (Player plyr in PlayersVisited)
            {
                if (plyr == p)
                {
                    result = true;
                }
            }
            if (result == false)
            {
                _visitedPlayers.Add(p);
            }
        }
        public void AddPath(Path p)
        {
            _paths.Add(p);
        }

        public void RemovePath(Path p)
        {
            _paths.Remove(p);
        }

        public Player CurrentPlayer(Player p)
        {
            foreach (Player plyr in PlayersVisited)
            {
                if (plyr == p)
                {
                    return plyr;
                }
            }
            return null;
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

        public string LocationDescription(Player p)
        {
            string search = FullDescription;
            search += "\nYou Can Also see: \n";

            foreach (Path pth in Paths)
            {
                search += pth.FullDescription(p) + "\n";
            }

            return search;
        }

        //figure out how to pass player into full description to decide if the player has visited it or not. Then it returns an alternante description to first iteraion of look command
        public override string FullDescription
        {
            get
            {
                string search = "\nYou look around " + Name + " And Can See: \n";
                foreach (string s in _area.ItemList)
                {
                    search += ("\n" + s + "\n");
                }

                return search;
            }
        }

    }
}
