using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using redbadger.martianrobot.game.Model;

namespace redbadger.martianrobot.game.Service
{
    internal class Grid
    {
        private readonly Coord _maxBounds = new Coord(0, 0);
        private IList<Coord> scentedCoords = new List<Coord>();

        public Grid(Coord maxBounds)
        {
            _maxBounds = maxBounds;
        }

        public bool IsPositionScented(Coord coord)
        {
            // TODO: could override GetHashCode in Coord class to use the 'List.contains' method for faster look up
            foreach (Coord scented in scentedCoords)
            {
                if (scented.Equals(coord)) { return true; }
            }
            return false;
        }

        
        public bool RobotLost(Robot robot)
        {
            bool isLost = robot.location.x > _maxBounds.x || robot.location.y > _maxBounds.y;

            if (isLost) { robot.RobotLost(); }
            return robot.isLost;
        }

    }
}
