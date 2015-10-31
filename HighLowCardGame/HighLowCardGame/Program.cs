using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~ Setting up the High-Low Card Game ~");
            Deck base_deck = new Deck();
            base_deck.Shuffle();
            foreach (Card aCard in base_deck.Cards)
            {
                Console.WriteLine(aCard);
            }
            Console.ReadKey();
        }
    }
}
