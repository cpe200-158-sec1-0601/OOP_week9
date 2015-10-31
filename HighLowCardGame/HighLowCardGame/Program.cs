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
            Player player1 = new Player(1);
            Player player2 = new Player(2);
            Control.SettingUp();
            Control.NewPlayers(player1, player2, "Sloth", "Death");
            Control.GivePlayerADeck(player1, player2);
            Console.WriteLine("== [Player 1] Card deck is containing these cards :");
            player1.PlayingDeck.ViewCardsinDeck();
            Console.WriteLine("== [Player 2] Card deck is containing these cards :");
            player2.PlayingDeck.ViewCardsinDeck();
            Console.WriteLine("");
            Console.WriteLine("");

            int result = 0;
            do
            {
                Console.WriteLine("Comparing player 1 and player 2 card deck");
                result = Control.CompareCardDeck(player1, player2);
                player1.ShowPlayerScore();
                player2.ShowPlayerScore();
                Console.WriteLine("== [Player 1] Card deck is containing of " + player1.PlayingDeck.Cards.Count + " card(s)");
                Console.WriteLine("== [Player 2] Card deck is containing of " + player2.PlayingDeck.Cards.Count + " card(s)");
                if (player1.PlayingDeck.Cards.Count == 0)
                {
                    Console.WriteLine("[Summary] No more card left in the both players card deck");
                    break;
                }
                Console.WriteLine("!----------------------!");
                //Console.ReadKey();
            } while (result != -1);
            Control.FinishPlaying(player1, player2);
            Console.ReadKey();
        }
    }
}