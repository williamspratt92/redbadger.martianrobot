using redbadger.martianrobot.game.Model;

namespace redbadger.martianrobot.tests
{
    public class UserInputTests_Bad
    {
        [Fact]
        public void NoInput()
        {
            UserInput userInput = new UserInput();

            Assert.False(userInput.isValid);
        }
        [Fact]
        public void EmptyImputs()
        {
            IList<string> simulatedInput = new List<string> {
                string.Empty,
                string.Empty,
                string.Empty };

            UserInput userInput = new UserInput(simulatedInput.ToArray());

            Assert.False(userInput.isValid);
        }
        [Fact]
        public void MissingData()
        {
            IList<string> simulatedInput = new List<string> {
                "5 3",
                "0 3 W" };

            UserInput userInput = new UserInput(simulatedInput.ToArray());

            Assert.False(userInput.isValid);
        }
        [Fact]
        public void IncorrectData()
        {
            IList<string> simulatedInput = new List<string> {
                "5 3 7",
                "0 D",
                "LLFFDFLFL" };

            UserInput userInput = new UserInput(simulatedInput.ToArray());

            Assert.False(userInput.isValid);
        }
    }
}