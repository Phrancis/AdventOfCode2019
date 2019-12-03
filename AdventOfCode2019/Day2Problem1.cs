using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2019
{
    class Day2Problem1
    {
        public readonly string ProblemUrl = "https://adventofcode.com/2019/day/2";
        public readonly string ProblemTitle = "Day 2: 1202 Program Alarm";
        public readonly string FileName = "D2P1.txt";
        private InputGetter inputGetter;
        private string rawInput;

        public Day2Problem1()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(FileName);
        }

        internal int SolveProblem()
        {
            IntcodeComputer computer = new IntcodeComputer(rawInput);
            List<int> result = computer.ComputeOpcodes(12, 2);
            Console.WriteLine(result.ToString());
            return result[0];
        }
    }
}
