using System;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    class Day2Problem2 : IAdventOfCodeProblem
    {
        private readonly string problemUrl = "https://adventofcode.com/2019/day/2#part2";
        private readonly string problemTitle = "Day 2: 1202 Program Alarm - Part 2";
        private readonly string fileName = "D2P1.txt";
        private InputGetter inputGetter;
        private string rawInput;

        public Day2Problem2()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(fileName);
        }

        public string FileName() => fileName;

        public string ProblemTitle() => problemTitle;

        public string ProblemUrl() => problemUrl;

        public int SolvePart1()
        {
            int targetOutput = 19690720;
            List<int> results;
            IntcodeComputer computer = new IntcodeComputer(rawInput);
            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    results = computer.ComputeOpcodes(noun, verb);
                    if (results[0] == targetOutput)
                    {
                        return (noun * 100) + verb;
                    }
                }
            }
            throw new Exception("Solution could not be found.");
        }

        public int SolvePart2()
        {
            return -1;
        }
    }
}
