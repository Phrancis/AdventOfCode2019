using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public int SolveProblem()
        {
            IntcodeComputer computer = new IntcodeComputer(rawInput);
            List<int> result = computer.ComputeOpcodes(12, 2);
            Console.WriteLine(result.ToString());
            return result[0];
        }
    }
}
