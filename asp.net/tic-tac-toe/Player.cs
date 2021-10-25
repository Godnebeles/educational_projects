using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public struct Player
    {
        private readonly string name;
        private readonly char playerSymbol;
        private readonly PlayerIdentificator playerIdentificator;

        public Player(string name, char playerSymbol, PlayerIdentificator playerIdentificator)
        {
            this.name = name;
            this.playerSymbol = playerSymbol;
            this.playerIdentificator = playerIdentificator;
        }

        public string Name { get { return name; } }
        public char PlayerSymbol { get { return playerSymbol; } }
        public PlayerIdentificator PlayerIdentificator { get { return playerIdentificator; } }

    }
}