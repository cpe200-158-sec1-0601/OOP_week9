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
            Player player1 = new Player();
            Player player2 = new Player();
            Control.SettingUp();
            Control.NewPlayers(player1, player2, "Sloth", "Death");
            Control.GivePlayerADeck(player1, player2);
            Console.WriteLine("[Player 1] Card deck is containing these cards :");
            player1.PlayingDeck.ViewCardsinDeck();
            Console.WriteLine("[Player 2] Card deck is containing these cards :");
            player2.PlayingDeck.ViewCardsinDeck();
            Console.ReadKey();
        }
    }
}