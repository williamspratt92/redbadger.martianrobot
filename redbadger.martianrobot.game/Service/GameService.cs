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
        protected Grid _grid;
        private Robot _robot;

        public GameService(Grid grid) {
            _grid = grid;
            _robot = new Robot(new Coord(0, 0), Orientation.North);
        }

        public string NewRobot(UserInput userInput)
        {

            _robot = new Robot(userInput.robotOriginalCoords, userInput.robotOriginalOrientation);

            return ExecuteCommands(userInput.commands);
        }

        private string ExecuteCommands(char[] commands) {
            
            var cmds = commands.GetEnumerator();
            int robotLastKnowPosition_X = _robot.location.x;
            int robotLastKnowPosition_Y = _robot.location.y;

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

                        // if current location has scent
                        // and next move takes off grid,
                        // skip move

                        // no scent => try move
                        if (!_grid.IsPositionScented(_robot.location)) {
                            _robot.MoveForward(); break;
                        }

                        // if scent => check safe, 
                        Coord coordNew = _robot.CalcMoveForward();
                        if (_grid.IsOnGrid(coordNew)) {
                            _robot.MoveForward();
                        }
                        // if not => skip
                        break;
                }

                if (_grid.RobotOnGrid(_robot))
                {
                    robotLastKnowPosition_X = _robot.location.x;
                    robotLastKnowPosition_Y = _robot.location.y;
                }
                else { break; }

            }

            Coord finalCoord = new Coord(robotLastKnowPosition_X, robotLastKnowPosition_Y);

            if (_robot.isLost)
            {
                _grid.AddScent(finalCoord);
            }

            return RobotStatus(finalCoord);
        }
        private string RobotStatus(Coord finalCoord) {
            string formatterOutput = "{0} {1} {2} {3}";


            return string.Format( formatterOutput,
                        finalCoord.x,
                        finalCoord.y,
                        _robot.orientation.ToString().First(),
                        _robot.isLost ? "LOST" : string.Empty
                        ).TrimEnd();
        }


    }
}
