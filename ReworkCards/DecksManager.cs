using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReworkCards
{
    internal class DecksManager : IDecksKeeper
    {
        private Dictionary<string, CardsDeck> _decks = new Dictionary<string, CardsDeck>();
        public bool HasDecks => _decks.Count != 0;

        public bool CreateCardDeck(string name)
        {
            try
            {
                _decks.Add(name, new CardsDeck());
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteCardDeck(string name)
        {
            try
            {
                _decks.Remove(name);
            }
            catch 
            {
                return false;
            }
            return true;
        }

        public CardsDeck GetDeck(string name)
        {
            return _decks[name];
        }

        public string[] GetNames()
        {
            return _decks.Keys.ToArray();
        }

        public bool MixDeck(string name)
        {
            try
            {
                _decks[name].Mix();
            }
            catch 
            { 
                return false;
            }
            return true;
        }
    }
}
