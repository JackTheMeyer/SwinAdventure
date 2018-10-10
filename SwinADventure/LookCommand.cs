using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    class LookCommand : Command
    {
        private string[] _identifiers;

        public LookCommand(string[] idents) :
            base(idents)
        {
            _identifiers = idents;
        }

        public override string Execute(Player p, string[] text)
        {
            //look at pen in bag 
            //look at bag in inventory
            //look at pen
            //look at bag


            if (text.Length != 3 & text.Length != 5)
            {
                return "I Don't Know How To Look Like That";
            }
            else if (text[0].ToLower() != "look")
            {
                return "Error In Look Input";
            }
            else if (text[1].ToLower() != "at")
            {
                return "What Do You Want To Look At?";
            }
            else if (text.Length == 5)
            {
                if (text[3].ToLower() != "in")
                {
                    return "What Do You Want To Look In?";
                }

                IHaveInventory cont = FetchContainer(p, text[4]);
                if (cont == null)
                {
                    return "I Can't Find The " + text[4];
                }

                string result = LookAtIn(text[2], cont);
                if (result == null)
                {
                    return "I Can't Find The " + text[2];
                }
                else
                {
                    return result;
                }

            }
            else if (text.Length == 3)
            {
                GameObject newp = p.Locate(text[2]);
                if (newp == null)
                {
                    return "I Can't Find The " + text[2];
                }
                else
                {
                    return newp.FullDescription;
                }

            }
            else
            {
                return "Something Went Wrong";
            }
        }

        public IHaveInventory FetchContainer(Player p, string containerid)
        {

            GameObject obj = p.Locate(containerid);
            IHaveInventory container = obj as IHaveInventory;
            return container;


        }

        public string[] Cmd
        {
            get
            {
                return _identifiers;
            }
        }
        public string LookAtIn(string thingid, IHaveInventory container)
        {
            GameObject result = container.Locate(thingid);
            if (result == null)
            {
                return null;
            }
            else
            {
                return result.FullDescription;
            }
            
        }

        
    }
}
