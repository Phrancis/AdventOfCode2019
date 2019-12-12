using System;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    class Day2Problem1 : IAdventOfCodeProblem
    {
        private readonly string problemUrl = "https://adventofcode.com/2019/day/2";
        private readonly string problemTitle = "Day 2: 1202 Program Alarm";
        private readonly string fileName = "D2P1.txt";
        private InputGetter inputGetter;
        private string rawInput;

        public Day2Problem1()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(fileName);
        }

        public string FileName() => fileName;

        public string ProblemTitle() => problemTitle;

        public string ProblemUrl() => problemUrl;

        public int SolvePart1()
        {
            IntcodeComputer computer = new IntcodeComputer(rawInput);
            List<int> result = computer.ComputeOpcodes(12, 2);
            return result[0];
        }

        public int SolvePart2()
        {
            return -1;
        }
    }
}
