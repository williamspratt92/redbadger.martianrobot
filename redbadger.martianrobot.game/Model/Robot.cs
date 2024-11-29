using redbadger.martianrobot.game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbadger.martianrobot.game.Model
{
    internal class Robot
    {
        public Coord location { get { return _location; } }
        public Orientation orientation { get { return _orientation; } }
        public bool isLost { get { return _isLost; } }

        private Coord _location = new Coord(0,0);
        private Orientation _orientation;
        private bool _isLost = false;

        public Robot(Coord location, Orientation orientation) { 
            this._location = location;
            this._orientation = orientation;
        }

        public void RobotLost() { _isLost = true; }

        public void MoveForward()
        {
            switch (_orientation)
            {
                case Orientation.North:
                    _location.y += 1; break;
                case Orientation.South:
                    _location.y -= 1; break;

                case Orientation.East:
                    _location.x += 1; break;
                case Orientation.West:
                    _location.x -= 1; break;

            }
        }
        public Coord CalcMoveForward()
        {
            int xChange = 0;
            int yChange = 0;


            switch (_orientation)
            {
                case Orientation.North:
                    yChange += 1; break;
                case Orientation.South:
                    yChange -= 1; break;

                case Orientation.East:
                    xChange += 1; break;
                case Orientation.West:
                    xChange -= 1; break;

            }

            return new Coord(_location.x + xChange, _location.y +yChange);
        }

        public void TurnRight() {

            if (_orientation == Orientation.West) { 
                _orientation = Orientation.North;
                return;
            }
            
            _orientation = (Orientation)((int)_orientation + 1);
        }
        public void TurnLeft()
        {

            if (_orientation == Orientation.North)
            {
                _orientation = Orientation.West;
                return;
            }

            _orientation = (Orientation)((int)_orientation - 1);
        }
    }
}
