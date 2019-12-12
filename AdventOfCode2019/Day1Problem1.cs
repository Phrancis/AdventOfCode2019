using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    class Day1Problem1 :IAdventOfCodeProblem
    {
        private readonly string problemUrl = "https://adventofcode.com/2019/day/1";
        private readonly string problemTitle = "Day 1: The Tyranny of the Rocket Equation";
        private readonly string fileName = "D1P1.txt";
        private InputGetter inputGetter;
        private string rawInput;

        public Day1Problem1()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(fileName);           
        }

        public string ProblemUrl() => problemUrl;

        public string ProblemTitle() => problemTitle;

        public string FileName() => fileName;

        public int SolvePart1()
        {
            List<string> inputs = rawInput.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            List<int> fuelCalculations = new List<int>();
            foreach (string input in inputs)
            {
                fuelCalculations.Add(CalculateFuel((Int32.Parse(input))));
            }
            int sum = 0;
            foreach (int unit in fuelCalculations)
            {
                sum += unit;
            }
            return sum;
        }

        public int SolvePart2()
        {
            return new Day1Problem2().SolvePart1();
        }

        public int CalculateFuel(int mass)
        {
            return (int)Math.Floor((double)mass / 3) - 2;
        }
    }
}
