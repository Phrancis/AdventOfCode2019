using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day5Problem1 : IAdventOfCodeProblem
    {
        private readonly string problemUrl = "https://adventofcode.com/2019/day/5";
        private readonly string problemTitle = "Day 5: Sunny with a Chance of Asteroids";
        private readonly string fileName = "D5P1.txt";
        private InputGetter inputGetter;
        private string rawInput;

        public Day5Problem1()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(fileName);
        }

        public string FileName() => fileName;

        public string ProblemTitle() => problemTitle;

        public string ProblemUrl() => problemUrl;

        public int SolveProblem()
        {
            throw new NotImplementedException();
        }
    }
}
