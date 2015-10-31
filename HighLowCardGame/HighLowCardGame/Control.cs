using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Control
    {
        static Deck base_deck;

        public static void SettingUp()
        {
            Console.WriteLine("~ Setting up the High-Low Card Game ~");
            base_deck = new Deck(13, 4);
            base_deck.Shuffle();
            foreach (Card aCard in base_deck.Cards)
            {
                Console.WriteLine(aCard);
            }
            Console.WriteLine("Base card deck is READY!");
        }
        public static void NewPlayers(Player pPlayer1, Player pPlayer2, string pPlayerName1 = "Anonymous", string pPlayerName2 = "Anonymous")
        {
            Console.WriteLine("Creating new two players...");
            pPlayer1.Name = pPlayerName1;
            pPlayer2.Name = pPlayerName2;
            Console.WriteLine("Player 1 is " + pPlayer1.Name);
            Console.WriteLine("Player 2 is " + pPlayer2.Name);
        }
        public static void GivePlayerADeck(Player pPlayer1, Player pPlayer2)
        {
            for (int i = 0; i < 26; i++)
            {
                pPlayer1.PlayingDeck.Cards.Add(base_deck.Cards[i]);
            }
            for (int i = 0; i < 26; i++)
            {
                pPlayer2.PlayingDeck.Cards.Add(base_deck.Cards[i + 26]);
            }
        }
        
        public static void CompareCardDeck(Deck pDeck1, Deck pDeck2)
        {
            if (pDeck1.Cards.Count != pDeck2.Cards.Count)
            {
                return; // Can't compare two decks
            }
        }
    }
}
