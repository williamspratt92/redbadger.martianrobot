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
        private Grid _grid;
        private Robot _robot;
        private UserInput _userInput;

        public GameService(UserInput userInput) {
            _userInput = userInput;

            // set objects
            _grid = new Grid(userInput.gridMaxCoords);
            _robot = new Robot(userInput.robotOriginalCoords, userInput.robotOriginalOrientation);
            
        }

        public void NewRobot()
        {

        }

        private void ExecuteCommands(bool showProgress = false) {
            
            var cmds = _userInput.commands.GetEnumerator();
            

            while (!_grid.RobotLost(_robot) && cmds.MoveNext())
            {
                switch (cmds.Current)
                {
                    case 'L':
                        _robot.TurnLeft(); break;

                    case 'R':
                        _robot.TurnRight(); break;

                    case 'F':
                        //TODO: SCENT TEST
                        _robot.MoveForward(); break;
                }

                if (showProgress) { RobotStatus(); }

            }


        }
        private void RobotStatus() {
            string formatterOutput = "{0} {1} {2} {3}";


            Console.WriteLine(formatterOutput,
                        _robot.location.x,
                        _robot.location.y,
                        _robot.orientation,
                        _robot.isLost ? "LOST" : string.Empty);
        }


    }
}
