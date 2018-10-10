using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _description;
        private string _name;

        public GameObject(string[] idents, string name, string desc) :
            base(idents)
        {
            _description = desc;
            _name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }
        public string ShortDescription
        {
            get
            {
                return FirstId + "(" + _name + ")";
            }
        }

        public abstract string FullDescription
        {
            get;
        }

    }
}
