using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Deck
    {
        public List<Card> Cards = new List<Card>();
    
        //public int[,] cards = new int[4,13];

        public Deck(int pValue = 13, int pSuit = 4)
        {
            for (int i = 0; i < pValue; i++)
            {
                for (int j = 0; j < pSuit; j++)
                {
                    Cards.Add(new Card { Value = i, Suit = j });
                    //Console.WriteLine("Added new card (value = " + i + ", suit = " + j + ") to the list.");
                }
            }
        }

        public void Shuffle()//(List<T> pDeck)
        {
            Random random = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                var j = random.Next(i, Cards.Count); // Don't select from the entire pDeck on subsequent loops
                var temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }
        }
    }
}
