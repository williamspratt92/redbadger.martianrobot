using redbadger.martianrobot.game.Model;
using redbadger.martianrobot.game.Resources;
using redbadger.martianrobot.game.Service;
using System;

namespace MyApp
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Grid grid = new Grid(SampleInputs.sampleGrid);
            GameService gameService = new GameService(grid);

            Console.WriteLine(gameService.NewRobot(new UserInput(SampleInputs.sampleInput1)));
            Console.WriteLine(gameService.NewRobot(new UserInput(SampleInputs.sampleInput2)));
            Console.WriteLine(gameService.NewRobot(new UserInput(SampleInputs.sampleInput3)));


        }

    }
}
