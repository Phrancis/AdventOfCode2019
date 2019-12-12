using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day5Problem2 : IAdventOfCodeProblem
    {
        private readonly string problemUrl = "https://adventofcode.com/2019/day/5#part2";
        private readonly string problemTitle = "Day 5: Sunny with a Chance of Asteroids - Part 2";
        private readonly string fileName = "D5P1.txt";
        private InputGetter inputGetter;
        private string rawInput;
        private IntcodeComputer computer;

        public Day5Problem2()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(fileName);
            computer = new IntcodeComputer(rawInput);
        }

        public string FileName() => fileName;

        public string ProblemTitle() => problemTitle;

        public string ProblemUrl() => problemUrl;

        public int SolvePart1()
        {
            computer.ComputeOpcodes(null, null, (int)SystemId.ThermalRadiators);
            Console.WriteLine(string.Join(",", computer.Output));
            return computer.Output[computer.Output.Count - 1];
        }

        public int SolvePart2()
        {
            return -1;
        }
    }
}
