using System;
using System.Drawing;
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
        private Day3Problem1 d3p1;
        public List<Point> wire1Points { get; private set; }
        public List<Point> wire2Points { get; private set; }
        public IEnumerable<Point> crossings { get; private set; }

        public Day3Problem2()
        {
            d3p1 = new Day3Problem1();
            d3p1.SolvePart1();
            wire1Points = d3p1.wire1Points;
            wire2Points = d3p1.wire2Points;
            crossings = d3p1.crossings;
        }

        public string FileName() => fileName;

        public string ProblemTitle() => problemTitle;

        public string ProblemUrl() => problemUrl;

        public int SolvePart1()
        {
            List<int> stepsForEachCrossing = new List<int>();
            foreach(Point c in crossings)
            {
                int wire1Steps = 0;
                int wire2Steps = 0;
                foreach (Point p in wire1Points)
                {
                    wire1Steps++;
                    if (p == c)
                    {
                        break;
                    }
                }
                foreach (Point p in wire2Points)
                {
                    wire2Steps++;
                    if (p == c)
                    {
                        break;
                    }
                }
                stepsForEachCrossing.Add(wire1Steps + wire2Steps);
            }
            int fewestSteps = int.MaxValue;
            foreach (int s in stepsForEachCrossing)
            {
                if (s != 0 && s < fewestSteps)
                {
                    fewestSteps = s;
                }
            }
            return fewestSteps;
        }

        public int SolvePart2()
        {
            return -1;
        }
    }
}
