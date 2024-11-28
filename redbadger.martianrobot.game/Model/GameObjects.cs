using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbadger.martianrobot.game.Model
{


    internal struct Coord
    {
        public readonly int x;
        public readonly int y;

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    internal enum Orientation { Default, North, South, East, West }

    internal enum RobotMoves { Left, Right, Forward }
}
