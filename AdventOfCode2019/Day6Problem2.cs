using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day6Problem2 : IAdventOfCodeProblem
    {
        private readonly string _problemUrl = "https://adventofcode.com/2019/day/6#part2";
        private readonly string _problemTitle = "Day 6: Universal Orbit Map - Part 2";
        private readonly string _fileName;
        private Day6Problem1 d6p1;

        public Day6Problem2()
        {
            d6p1 = new Day6Problem1();
            _fileName = d6p1.FileName();
        }

        public string FileName() => _fileName;

        public string ProblemTitle() => _problemTitle;

        public string ProblemUrl() => _problemUrl;

        public int SolvePart1()
        {
            d6p1.PopulateMap();
            var map = d6p1.GetOrbitMap();
            return map.OrbitalJumpsBetween(
                map.FindOrbitingObject("YOU").Parent,
                map.FindOrbitingObject("SAN").Parent);
        }

        public int SolvePart2()
        {
            return -1;
        }
    }
}
