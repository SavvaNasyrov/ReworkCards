﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReworkCards
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var deck = new CardsDeck();

            deck.PrintAllCards();

            Console.ReadKey();
        }
    }
}
