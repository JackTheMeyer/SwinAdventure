using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Path
    {
        private Location _fwdDirection = null;
        private Location _bckDirection = null;

        private bool _locked = false;

        private string[] _identifiers;
        private string _name;
        private string _description;

        public Path(string[] idents, string name, string desc, Location backward, Location forward) 
        {
            _bckDirection = backward;
            _fwdDirection = forward;

            _identifiers = idents;
            _name = name;
            _description = desc;

        }

        public bool Locked
        {
            get
            {
                return _locked;
            }
            set
            {
                _locked = value;
            }
        }

        public string[] Identifiers
        {
            get
            {
                return _identifiers;
            }
        }

        public Location FwdDirection
        {
            get
            {
                return _fwdDirection;
            }
        }

        public Location BckDirection
        {
            get
            {
                return _bckDirection;
            }
        }

        public void MovePlayer(Player p)
        {

                p.Location = _fwdDirection;
                p.Location.PlayerVisits(p);

        }

        public string FullDescription(Player p)
        {
            bool playerVisit = false;

            foreach (Player pcheck in _fwdDirection.PlayersVisited)
            {
                if (p == pcheck)
                {
                    playerVisit = true;
                }
            }

            if (playerVisit)
            {
                if (p.Location == _bckDirection)
                {
                    return _description + " This Path Leads To " + _fwdDirection.Name + ".";
                }
                else
                {
                    return _description + " This Path Leads To " + _bckDirection.Name + ".";
                }
            }
            else
            {
                return _description + " You Are Unsure Where It Leads.";
            }
        }



    }
}
