using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReworkCards
{
    internal interface IDecksKeeper
    {
        bool HasDecks { get; }
        bool CreateCardDeck(string name);
        bool DeleteCardDeck(string name);
        string[] GetNames();
        bool MixDeck(string name);
        CardsDeck GetDeck(string name);
    }
}
