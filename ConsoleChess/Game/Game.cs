using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class Game
    {
        private Player[] players;
        private World world;
        private Player currentTurn;
        private EnumGameStatus status;
        private List<Move> movesPlayed;

        private void initialize(Player p1, Player p2)
        {
            players[0] = p1;
            players[1] = p2;

            //world.resetBoard();
        }
    }
}
