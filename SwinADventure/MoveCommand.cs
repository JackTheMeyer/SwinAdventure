using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    class MoveCommand : Command
    {
        private string[] _identifiers;

        public MoveCommand(string[] idents) :
            base(idents)
        {
            _identifiers = idents;
        }

        public override string Execute(Player p, string[] text)
        {
            bool valid = false;
            switch (text[0].ToLower())
            {
                case "move":
                    valid = true;
                    break;
                case "leave":
                    valid = true;
                    break;
                case "head":
                    valid = true;
                    break;
                case "go":
                    valid = true;
                    break;
                default:
                    valid = false;
                    break;
            }

            if (valid == false)
            {
                return "I'm not sure what you mean.";
            }

            if (text.Length == 1)
            {
                return "Where would you like to go?";
            }
            else if (text.Length == 2)
            {
                foreach (Path pth in p.Location.Paths)
                {

                    foreach (string s in pth.Identifiers)
                    {
                        if (s == text[1].ToLower())
                        {
                           pth.MovePlayer(p);
                            return "Heading " + s + "!\nYou arrive at " + pth.FwdDirection.Name;
                        }
                        else
                        {
                            return "you can't go " + text[1] + "!";
                        }
                    }
                }
            }

            return null;
        }   

    }
}
