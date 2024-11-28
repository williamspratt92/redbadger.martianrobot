using redbadger.martianrobot.game.Model;

namespace redbadger.martianrobot.tests
{
    public class UserInputTests
    {
        [Fact]
        public void SampleInput_1()
        {
            IList<string> simulatedInput = new List<string> {
                "5 3",
                "1 1 E",
                "RFRFRFRF" };
            
            UserInput userInput = new UserInput(simulatedInput.ToArray());

            Assert.True(userInput.isValid);
        }
        [Fact]
        public void SampleInput_2()
        {
            IList<string> simulatedInput = new List<string> {
                "5 3",
                "3 2 N",
                "FRRFLLFFRRFLL" };

            UserInput userInput = new UserInput(simulatedInput.ToArray());

            Assert.True(userInput.isValid);
        }
        [Fact]
        public void SampleInput_3()
        {
            IList<string> simulatedInput = new List<string> {
                "5 3",
                "0 3 W",
                "LLFFFLFLFL" };

            UserInput userInput = new UserInput(simulatedInput.ToArray());

            Assert.True(userInput.isValid);
        }
    }
}