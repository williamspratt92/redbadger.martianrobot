using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace redbadger.martianrobot.game.Resources
{
    internal static class SampleInputs
    {
        public static readonly string sampleGrid = "5 3";

        public static readonly string[] sampleInput1 = { "1 1 E", "RFRFRFRF" };
        public static readonly string[] sampleInput2 = { "3 2 N", "FRRFLLFFRRFLL" };
        public static readonly string[] sampleInput3 = { "0 3 W", "LLFFFLFLFL" };

        public static readonly string sampleOutput1 = "1 1 E" ;
        public static readonly string sampleOutput2 = "3 3 N LOST";
        public static readonly string sampleOutput3 = "2 3 S";
    }
}
