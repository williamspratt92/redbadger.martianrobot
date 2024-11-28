using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("redbadger.martianrobot.tests")]

namespace redbadger.martianrobot.game.Model
{
    internal struct UserInput
    {
        //public readonly Coord gridMaxCoords;
        public readonly Coord robotOriginalCoords;
        public readonly Orientation robotOriginalOrientation;
        public readonly char[] commands = Array.Empty<char>();
        public readonly bool isValid = false;

        public UserInput(string[] userInputs)
        {
            // lack of data
            if (userInputs == null)
            {
                Console.WriteLine($"Invalid user input");
            }
            else if (userInputs.Length < 2)
            {
                Console.WriteLine($"Invalid user input");
            }

            // validate
            
            else if (!ValidateRobotInput(userInputs[0], out robotOriginalCoords, out robotOriginalOrientation))
            {
                Console.WriteLine($"Invalid robot position: '{userInputs[0]}'");
            }
            else if (!ValidateCommands(userInputs[1], out commands))
            {
                Console.WriteLine($"Invalid command sequence: '{userInputs[1]}'");
            }

            // must be valid
            else { isValid = true; }
        }

        #region validations
        bool ValidateRobotInput(string inputStr, out Coord coord, out Orientation orientation)
        {
            // default return type for out
            coord = new Coord(0, 0);
            orientation = Orientation.North;

            // null test
            if (string.IsNullOrEmpty(inputStr)) { return false; }

            // too few test
            string[] inputs = inputStr.Split(' ');
            if (inputs.Length != 3) { return false; }

            // can convert to int
            int[] ints = inputs.Take(2).Select(c => Convert.ToInt32(c)).ToArray();

            // out type
            coord = new Coord(ints[0], ints[1]);
            return ValidateOrientation(inputs[2], out orientation);
        }
        
        bool ValidateOrientation(string orientationStr, out Orientation orientation)
        {
            orientation = Orientation.North;

            if (string.IsNullOrEmpty(orientationStr)) { return false; }
            if (orientationStr.Length != 1) { return false; }

            switch (orientationStr)
            {
                case "N":
                    orientation = Orientation.North;
                    return true;
                case "S":
                    orientation = Orientation.South;
                    return true;
                case "E":
                    orientation = Orientation.East;
                    return true;
                case "W":
                    orientation = Orientation.West;
                    return true;

                default:
                    return false;
            }
        }
        bool ValidateCommands(string inputStr, out char[] commands)
        {
            commands = Array.Empty<char>();

            // null test
            if (string.IsNullOrEmpty(inputStr)) { return false; }

            // robot moves
            char[] validMoves = Enum.GetValues<RobotMoves>().Select(m => m.ToString().First()).ToArray();
            

            foreach (char c in inputStr)
            {
                if (!validMoves.Contains(c)) { return false; }
            }

            commands = inputStr.ToCharArray();
            return true;
        }
        #endregion

    }

}
