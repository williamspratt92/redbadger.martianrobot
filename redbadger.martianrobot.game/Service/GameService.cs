using redbadger.martianrobot.game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbadger.martianrobot.game.Service
{
    internal class GameService
    {
        private Grid _grid = new Grid(new Coord(0,0));
        private Robot _robot = new Robot();

        public GameService() {
        }

        public void Play(UserInput userInput) {
            _grid = new Grid(userInput.gridMaxCoords);

        }
    }
}
