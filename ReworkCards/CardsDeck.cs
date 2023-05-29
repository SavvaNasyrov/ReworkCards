using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;

namespace ReworkCards
{
    internal class CardsDeck
    {
        private Card[] _cards = new Card[52];
        private string _mixingMode;

        public CardsDeck() 
        {
            _mixingMode = ConfigurationManager.AppSettings["mixingmode"];
            SetDefaultCards();
        }

        private bool SetDefaultCards()
        {
            var Reader = XmlReader.Create("..\\..\\Properties\\DefaultCards.xml");
            Reader.Read();
            Reader.Read();
            Reader.Read();
            Reader.Read();
            Reader.Read();
            Reader.Read();
            Reader.Read();

            for (int i = 0; i < 52; i++)
            {
                _cards[Convert.ToInt32(Reader.GetAttribute("key"))] = new Card(Reader.GetAttribute("value"));
                Reader.Read();
                Reader.Read();
            }

            return true;
        }

        public void PrintAllCards()
        {
            for (int i = 0; i < _cards.Length; i++)
            {
                Console.WriteLine($"{i} - {_cards[i].Name}");
            }
        }
    }
}
