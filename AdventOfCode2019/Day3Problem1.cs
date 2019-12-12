using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace AdventOfCode2019
{
    internal class Day3Problem1 : IAdventOfCodeProblem
    {
        private readonly string problemUrl = "https://adventofcode.com/2019/day/3";
        private readonly string problemTitle = "Day 3: Crossed Wires";
        private readonly string fileName = "D3P1.txt";
        private InputGetter inputGetter;
        private string rawInput;

        public List<Point> wire1Points { get; private set; }
        public List<Point> wire2Points { get; private set; }
        public IEnumerable<Point>  crossings { get; private set; }

        public Day3Problem1()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(fileName);
        }

        public string FileName() => fileName;

        public string ProblemTitle() => problemTitle;

        public string ProblemUrl() => problemUrl;

        public string RawInput() => rawInput;

        public int SolvePart1()
        {
            string[] input = rawInput.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            List<string> wire1Data = new List<string>(input[0].Split(','));
            List<string> wire2Data = new List<string>(input[1].Split(','));

            wire1Points = CalculatePoints(wire1Data);
            wire2Points = CalculatePoints(wire2Data);

            crossings = from point in wire1Points.Intersect(wire2Points)
                        select point;

            List<int> distances = new List<int>();
            foreach (Point c in crossings)
            {
                distances.Add(DistanceFromOrigin(c));
            }

            int shortestDistance = int.MaxValue;
            foreach (int d in distances)
            {
                if (d < shortestDistance)
                    shortestDistance = d;
            }
            return shortestDistance;
        }

        public int SolvePart2()
        {
            return new Day3Problem2().SolvePart1();
        }

        private List<Point> CalculatePoints(List<string> instructions)
        {
            List<Point> points = new List<Point>();
            Point currentPoint = new Point(0, 0);
            foreach (string inst in instructions)
            {
                char direction = inst[0];
                int distance = int.Parse(inst.Substring(1));
                switch (direction)
                {
                    case 'U':
                        for (int d = distance; d > 0; d--)
                        {
                            currentPoint += new Size(0, 1);
                            points.Add(currentPoint);
                        }
                        break;
                    case 'D':
                        for (int d = distance; d > 0; d--)
                        {
                            currentPoint += new Size(0, -1);
                            points.Add(currentPoint);
                        }
                        break;
                    case 'R':
                        for (int d = distance; d > 0; d--)
                        {
                            currentPoint += new Size(1, 0);
                            points.Add(currentPoint);
                        }
                        break;
                    case 'L':
                        for (int d = distance; d > 0; d--)
                        {
                            currentPoint += new Size(-1, 0);
                            points.Add(currentPoint);
                        }
                        break;
                    default:
                        throw new InvalidOperationException($"Direction '{direction}' is undefined.");
                }
            }
            return points;
        }

        private int DistanceFromOrigin(Point point) => Math.Abs(point.X) + Math.Abs(point.Y);
    }
}