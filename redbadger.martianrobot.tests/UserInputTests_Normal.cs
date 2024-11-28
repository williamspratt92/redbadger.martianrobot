using redbadger.martianrobot.game.Model;
using redbadger.martianrobot.game.Resources;

namespace redbadger.martianrobot.tests
{
    public class UserInputTests_Normal
    {
        [Fact]
        public void SampleInput_1()
        {
            UserInput userInput = new UserInput(SampleInputs.sampleInput1);

            Assert.True(userInput.isValid);
        }
        [Fact]
        public void SampleInput_2()
        {
            UserInput userInput = new UserInput(SampleInputs.sampleInput2);

            Assert.True(userInput.isValid);
        }
        [Fact]
        public void SampleInput_3()
        {
            UserInput userInput = new UserInput(SampleInputs.sampleInput3);

            Assert.True(userInput.isValid);
        }
    }
}