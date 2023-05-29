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

        public void Mix()
        {
            if (_mixingMode == "hand")
                HandMix();
            else
                SimpleMix();
        }

        private void HandMix()
        {
            Random random = new Random();
            for (int j = 0; j < 10; j++)
            {
                int starts = random.Next(_cards.Length / 2 - _cards.Length / 5, _cards.Length / 2 + _cards.Length / 5);

                Card[] first = new Card[starts];
                Card[] second = new Card[_cards.Length - starts];

                int counter = 0;

                for (int i = 0; i < starts; i++)
                {
                    first[i] = _cards[i];
                    counter = i;
                }

                counter++;

                for (int i = 0; i < second.Length; i++, counter++)
                {
                    second[i] = _cards[counter];
                }

                counter = 0;

                for (int i = 0; i < second.Length; i++)
                {
                    _cards[i] = second[i];
                    counter = i;
                }

                for (int i = 0; i < first.Length; i++, counter++)
                {
                    _cards[counter] = first[i];
                }
            }
        }

        private void SimpleMix()
        {
            Random rand = new Random();
            for (int i = _cards.Length - 1; i >= 1; i--)
            {
                int j = rand.Next() % (i + 1);

                Card tmp = _cards[j];
                _cards[j] = _cards[i];
                _cards[i] = tmp;
            }
        }
    }
}
