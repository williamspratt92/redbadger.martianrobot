using redbadger.martianrobot.game.Model;
using redbadger.martianrobot.game.Resources;
using redbadger.martianrobot.game.Service;
using System;

namespace MyApp
{
    internal class Program
    {
        static GameService _gameService = new GameService(new Grid(string.Empty));

        static void Main(string[] args)
        {
            Grid grid = new Grid(SampleInputs.sampleGrid);
            _gameService = new GameService(grid);

            Console.WriteLine(_gameService.NewRobot(new UserInput(SampleInputs.sampleInput1)));
            Console.WriteLine(_gameService.NewRobot(new UserInput(SampleInputs.sampleInput2)));
            Console.WriteLine(_gameService.NewRobot(new UserInput(SampleInputs.sampleInput3)));


        }

    }
}
