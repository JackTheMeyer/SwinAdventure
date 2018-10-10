using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {
            foreach (string s in idents)
            {
                _identifiers.Add(s);
            }
        }

        public string FirstId
        {
            get
            {
                if (_identifiers[0] != null)
                {
                    return _identifiers[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public bool AreYou(string id)
        {
            foreach (string s in _identifiers)
            {
                if (id.ToLower() == s.ToLower())
                {
                    return true;
                }
            }

            return false;
        }


        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

    }
}
