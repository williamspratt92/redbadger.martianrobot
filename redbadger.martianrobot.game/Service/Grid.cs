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
        private IList<Coord> _scentedCoords = new List<Coord>();

        public Grid(string userInput)
        {

            if (!ValidateGridInput(userInput, out _maxBounds))
            {
                Console.WriteLine($"Invalid grid coords: '{userInput}'");
            }
        }
        bool ValidateGridInput(string coordStr, out Coord coord)
        {
            // default return type for out
            coord = new Coord(0, 0);

            // null test
            if (string.IsNullOrEmpty(coordStr)) { return false; }

            // too few test
            string[] coords = coordStr.Split(' ');
            if (coords.Length != 2) { return false; }

            // can convert to int
            int[] ints = coords.Select(c => Convert.ToInt32(c)).ToArray();

            // out type
            coord = new Coord(ints[0], ints[1]);
            return true;
        }
        public bool IsPositionScented(Coord coord)
        {
            // TODO: could override GetHashCode in Coord class to use the 'List.contains' method for faster look up
            foreach (Coord scented in _scentedCoords)
            {
                if (scented.Equals(coord)) { return true; }
            }
            return false;
        }
        public void AddScent(Coord coord)
        {
            _scentedCoords.Add(coord);
        }
        
        public bool RobotOnGrid(Robot robot)
        {
            bool onGrid = robot.location.x >= 0 
                && robot.location.x <= _maxBounds.x
                && robot.location.y >= 0
                && robot.location.y <= _maxBounds.y
                ;

            if (!onGrid) {
                robot.RobotLost();
            }

            return onGrid;
        }

    }
}
