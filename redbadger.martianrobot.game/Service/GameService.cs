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

        public GameService(Grid grid) {
            _grid = grid;
            _robot = new Robot(new Coord(0, 0), Orientation.North);
        }

        public string NewRobot(UserInput userInput, bool showRobotPath = false)
        {

            _robot = new Robot(userInput.robotOriginalCoords, userInput.robotOriginalOrientation);

            return ExecuteCommands(userInput.commands, showRobotPath);
        }

        private string ExecuteCommands(char[] commands, bool showRobotPath = false) {
            
            var cmds = commands.GetEnumerator();
            Coord robotLastKnowPosition = _robot.location;

            while (_grid.RobotOnGrid(_robot) && cmds.MoveNext())
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

                if (!_robot.isLost)
                {
                    robotLastKnowPosition = _robot.location;
                }

                if (showRobotPath) { PrintRobotStatus(); }

            }

            if (_robot.isLost)
            {
                _grid.AddScent(robotLastKnowPosition);
            }

            return RobotStatus();
        }
        private void PrintRobotStatus()
        {
            Console.WriteLine(RobotStatus());
        }

        protected string RobotStatus() {
            string formatterOutput = "{0} {1} {2} {3}";


            return string.Format( formatterOutput,
                        _robot.location.x,
                        _robot.location.y,
                        _robot.orientation.ToString().First(),
                        _robot.isLost ? "LOST" : string.Empty
                        ).TrimEnd();
        }


    }
}
