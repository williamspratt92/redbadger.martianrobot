using redbadger.martianrobot.game.Model;
using redbadger.martianrobot.game.Service;

namespace redbadger.martianrobot.tests
{
    public class GridTests
    {
        [Fact]
        public void RobotLost()
        {
            Grid grid = new Grid("5 3");

            Assert.False(grid.RobotOnGrid(new Robot(new Coord(10, 10), Orientation.North)));
        }
        [Fact]
        public void RobotLostNeg()
        {
            Grid grid = new Grid("5 3");

            Assert.False(grid.RobotOnGrid(new Robot(new Coord(-1, 0), Orientation.North)));
        }
        [Fact]
        public void RobotOnGrid()
        {
            Grid grid = new Grid("5 3");

            Assert.True(grid.RobotOnGrid(new Robot(new Coord(0, 0), Orientation.North)));
        }
    }
}