using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbadger.martianrobot.game.Model
{
    internal class Coord
    {
        public int x;
        public int y;

        // TODO: validate not negative coords
        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Coord other = obj as Coord;
            if (other == null) return false;

            return x == other.x && y == other.y;
        }
    }

}
