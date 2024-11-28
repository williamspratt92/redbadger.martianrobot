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
        public string GetOutput() { return base.RobotStatus(); }
    }


    public class GameTests
    {
        [Fact]
        public void SampleInput()
        {
            MockGameService gameService = new MockGameService(new Grid(SampleInputs.sampleGrid));
            gameService.NewRobot(new UserInput(SampleInputs.sampleInput1));
            gameService.NewRobot(new UserInput(SampleInputs.sampleInput2));
            gameService.NewRobot(new UserInput(SampleInputs.sampleInput3));

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
        }

    }
}