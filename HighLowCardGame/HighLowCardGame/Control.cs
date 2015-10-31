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
            //base_deck.ViewCardsinDeck();
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
            Console.WriteLine("[Control] Two players card deck are each equal to the number of cards");
        }

        public static void PlayerWinTurn(Player pPlayer, int NumberofCards = 1)
        {
            pPlayer.Count += (NumberofCards) * 2;
            Console.WriteLine("[WIN][Player " + pPlayer.Order + "] PlayerWinTurn get 2 card into his/her pile");
        }
        public static void TieTurn(Player pPlayer1, Player pPlayer2)
        {
            Console.WriteLine("[Tie] Reshuffle the both players card deck");
            pPlayer1.PlayingDeck.Shuffle();
            pPlayer2.PlayingDeck.Shuffle();
        }

        public static void RemovePlayerCards(Player pPlayer1, Player pPlayer2, int range)
        {
            int LastCard = pPlayer1.PlayingDeck.Cards.Count - 1;
            pPlayer1.PlayingDeck.Cards.RemoveRange(LastCard - range + 1, range);
            pPlayer2.PlayingDeck.Cards.RemoveRange(LastCard - range + 1, range);
            Console.WriteLine("[Remove] " + range + " card(s) of both players card deck");
        }

        public static int CompareCardDeck(Player pPlayer1, Player pPlayer2)
        {
            if (pPlayer1.PlayingDeck.Cards.Count == 0)
            {
                Console.WriteLine("[Summary] No more card left in the both players card deck");
                return -1;
            }
            int LastCard = pPlayer1.PlayingDeck.Cards.Count - 1;
            int pPlayer1_last = pPlayer1.PlayingDeck.Cards[LastCard].Value;
            int pPlayer2_last = pPlayer2.PlayingDeck.Cards[LastCard].Value;
            Console.WriteLine("Player 1 has " + pPlayer1.PlayingDeck.Cards[LastCard]);
            Console.WriteLine("Player 2 has " + pPlayer2.PlayingDeck.Cards[LastCard]);
            if (pPlayer1_last == pPlayer2_last)
            {
                if (pPlayer1.PlayingDeck.Cards.Count == 1)
                {
                    Console.WriteLine("[Tie] The last card of both players is the same.");
                    return -1;
                }
                int NumberFromLastCard = pPlayer1_last;
                if (NumberFromLastCard > LastCard)
                {
                    TieTurn(pPlayer1, pPlayer2);
                    Console.WriteLine("== [Player 1] Card deck is containing these cards :");
                    pPlayer1.PlayingDeck.ViewCardsinDeck();
                    Console.WriteLine("== [Player 2] Card deck is containing these cards :");
                    pPlayer2.PlayingDeck.ViewCardsinDeck();
                    //Console.ReadKey();
                    return 0;
                }
                Console.WriteLine("Player 1 has " + pPlayer1.PlayingDeck.Cards[NumberFromLastCard]);
                Console.WriteLine("Player 2 has " + pPlayer2.PlayingDeck.Cards[NumberFromLastCard]);
                int pPlayer1_fromlast = pPlayer1.PlayingDeck.Cards[NumberFromLastCard].Value;
                int pPlayer2_fromlast = pPlayer2.PlayingDeck.Cards[NumberFromLastCard].Value;
                if (pPlayer1_fromlast > pPlayer2_fromlast)
                {
                    PlayerWinTurn(pPlayer1, NumberFromLastCard);
                    RemovePlayerCards(pPlayer1, pPlayer2, NumberFromLastCard);
                    return 1;
                }
                else if (pPlayer1_fromlast < pPlayer2_fromlast)
                {
                    PlayerWinTurn(pPlayer2, NumberFromLastCard);
                    RemovePlayerCards(pPlayer1, pPlayer2, NumberFromLastCard);
                    return 2;
                }
                else
                {
                    TieTurn(pPlayer1, pPlayer2);
                    return 0;
                }
            }
            // Player 1 WIN
            else if (pPlayer1_last > pPlayer2_last)
            {
                PlayerWinTurn(pPlayer1);
                RemovePlayerCards(pPlayer1, pPlayer2, 1);
                return 1;
            }
            // Player 2 WIN
            else if (pPlayer1_last < pPlayer2_last)
            {
                PlayerWinTurn(pPlayer2);
                RemovePlayerCards(pPlayer1, pPlayer2, 1);
                return 2;
            }
            return -1;
        }

        public static void FinishedPlaying(Player pPlayer1, Player pPlayer2)
        {
            Console.WriteLine("");
            Console.WriteLine("=== [ The winner is " + (pPlayer1.Count > pPlayer2.Count ? "player 1" : "player 2") +" ] ===");
        }
    }
}