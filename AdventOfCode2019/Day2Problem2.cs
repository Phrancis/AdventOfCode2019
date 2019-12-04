using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day2Problem2
    {
        public readonly string ProblemUrl = "https://adventofcode.com/2019/day/2#part2";
        public readonly string ProblemTitle = "Day 2: 1202 Program Alarm - Part 2";
        public readonly string FileName = "D2P1.txt";
        private InputGetter inputGetter;
        private string rawInput;

        public Day2Problem2()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(FileName);
        }

        public int SolveProblem()
        {
            int targetOutput = 19690720;
            List<int> results;
            Console.WriteLine(rawInput);
            IntcodeComputer computer = new IntcodeComputer(rawInput);
            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    results = computer.ComputeOpcodes(noun, verb);
                    Console.WriteLine(results.ToString());
                    if (results[0] == targetOutput)
                    {
                        Console.WriteLine((noun * 100) + verb);
                        return (noun * 100) + verb;
                    }
                }
            }
            throw new Exception("Solution could not be found");
        }
    }
}
