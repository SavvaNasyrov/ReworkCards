using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReworkCards
{
    internal class Card
    {
        string _name;
        public string Name { get { return _name; } }

        public Card() { }
        public Card(string name) => this._name = name;
    }
}
