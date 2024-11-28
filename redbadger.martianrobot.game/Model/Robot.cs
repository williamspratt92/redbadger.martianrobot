using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbadger.martianrobot.game.Model
{
    internal class Robot
    {
        
        private Coord _location = new Coord(0,0);
        private Orientation _orientation;

        public Robot(Coord location, Orientation orientation) { 
            this._location = location;
            this._orientation = orientation;
        }

        public void IncreaseX(int change) { _location.x += change; }
        public void IncreaseY(int change) { _location.y += change; }
        public void TurnLeft() { Orientation}
    }
}
