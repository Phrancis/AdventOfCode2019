using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day3Problem2 : IAdventOfCodeProblem
    {
        private readonly string problemUrl = "https://adventofcode.com/2019/day/3#part2";
        private readonly string problemTitle = "Day 3: Crossed Wires - Part 2";
        private readonly string fileName = "D3P1.txt";
        private InputGetter inputGetter;
        private string rawInput;
        private Day3Problem1 d3p1;

        public Day3Problem2()
        {
            d3p1 = new Day3Problem1();
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
