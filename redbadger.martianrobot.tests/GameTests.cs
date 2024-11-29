using redbadger.martianrobot.game.Model;
using redbadger.martianrobot.game.Resources;
using redbadger.martianrobot.game.Service;

namespace redbadger.martianrobot.tests
{
    internal class MockGameService : GameService
    {
        public MockGameService(Grid grid) : base(grid)
        {

        }

        public Grid grid { get { return base._grid; } }
    }


    public class GameTests
    {
        [Fact]
        public void CreatesScent()
        {
            MockGameService gameService = new MockGameService(new Grid(SampleInputs.sampleGrid));
            gameService.NewRobot(new UserInput(SampleInputs.sampleInput2));

            Assert.True( gameService.grid.IsPositionScented(new Coord(3, 3)) );
        }
        [Fact]
        public void SampleInput()
        {
            MockGameService gameService = new MockGameService(new Grid(SampleInputs.sampleGrid));

            Assert.Equal(
                SampleInputs.sampleOutput1,
                gameService.NewRobot(new UserInput(SampleInputs.sampleInput1))
                );
            Assert.Equal(
                SampleInputs.sampleOutput2,
                gameService.NewRobot(new UserInput(SampleInputs.sampleInput2))
                );
            Assert.Equal(
                SampleInputs.sampleOutput3,
                gameService.NewRobot(new UserInput(SampleInputs.sampleInput3))
                );
            
            // repeat sample 2
            Assert.Equal(
                "3 2 N",
                gameService.NewRobot(new UserInput(SampleInputs.sampleInput2))
                );
            
        }

    }
}