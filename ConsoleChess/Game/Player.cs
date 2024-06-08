using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public abstract class Player
    {
        public bool whiteSide;
        public bool humanPlayer;

        public bool isWhiteSide()
        {
            return this.whiteSide;
        }
        public bool isHumanPlayer()
        {
            return this.humanPlayer;
        }
    }
    public class HumanPlayer : Player
    {
        public HumanPlayer(bool whiteSide)
        {
            this.whiteSide = whiteSide;
            this.humanPlayer = true;
        }
    }
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(bool whiteSide)
        {
            this.whiteSide = whiteSide;
            this.humanPlayer = false;
        }
    }
}
