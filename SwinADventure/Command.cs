using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public abstract class Command : IdentifiableObject
    {
        private string[] _identifiers;

        public Command(string[] idents) :
            base(idents)
        {
            _identifiers = idents;
        }

        public abstract string Execute(Player p, string[] text);

    }
}
