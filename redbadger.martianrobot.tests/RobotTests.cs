using redbadger.martianrobot.game.Model;
using redbadger.martianrobot.game.Service;

namespace redbadger.martianrobot.tests
{
    public class RobotTests
    {
        [Fact]
        public void CanMoveFwd_North()
        {
            Robot robot = new Robot(new Coord(0,0), Orientation.North);
            robot.MoveForward();

            Assert.True(robot.location.y == 1 && robot.location.x == 0);
        }
        [Fact]
        public void CanMoveFwd_East()
        {
            Robot robot = new Robot(new Coord(0, 0), Orientation.East);
            robot.MoveForward();

            Assert.True(robot.location.y == 0 && robot.location.x == 1);
        }
        [Fact]
        public void CanTurn_Left()
        {
            Robot robot = new Robot(new Coord(0, 0), Orientation.North);
            robot.TurnLeft();

            Assert.True(robot.orientation == Orientation.West);
        }
        [Fact]
        public void CanTurn_Right()
        {
            Robot robot = new Robot(new Coord(0, 0), Orientation.West);
            robot.TurnRight();

            Assert.True(robot.orientation == Orientation.North);
        }
    }
}