using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Player
    {
        private Deck _playingdeck;
        private int _count;
        private string _name;

        public Deck PlayingDeck
        {
            get;
            set;
        }
        public int Count
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public Player(string pName = "Anonymous")
        {
            PlayingDeck = new Deck();
            Count = 0;
            Name = pName;
        }
    }
}
