using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2019
{
    class Day1Problem1
    {
        public readonly string ProblemUrl = "https://adventofcode.com/2019/day/1";
        public readonly string ProblemTitle = "Day 1: The Tyranny of the Rocket Equation";
        public readonly string FileName = "D1P1.txt";
        private InputGetter inputGetter;
        private string rawInput;

        public Day1Problem1()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(FileName);           
        }

        public int SolveProblem()
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

        public int CalculateFuel(int mass)
        {
            return (int)Math.Floor((double)mass / 3) - 2;
        }
    }
}
