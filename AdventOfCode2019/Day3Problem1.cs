using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    internal class Day3Problem1 : IAdventOfCodeProblem
    {
        private readonly string problemUrl = "https://adventofcode.com/2019/day/3";
        private readonly string problemTitle = "Day 3: Crossed Wires";
        private readonly string fileName = "D3P1.txt";
        private InputGetter inputGetter;
        private string rawInput;

        public Day3Problem1()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(fileName);
        }

        public string FileName() => fileName;

        public string ProblemTitle() => problemTitle;

        public string ProblemUrl() => problemUrl;

        public int SolveProblem()
        {
            string[] input = rawInput.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            List<string> wire1Data = new List<string>(input[0].Split(','));
            List<string> wire2Data = new List<string>(input[1].Split(','));

            List<Point2D> wire1Points = CalculatePoints(wire1Data);
            List<Point2D> wire2Points = CalculatePoints(wire2Data);

            IEnumerable<Point2D> crossings = from point in wire1Points.Intersect(wire2Points)
                                             select point;

            List<int> distances = new List<int>();
            foreach (Point2D c in crossings)
            {
                distances.Add(c.DistanceFromOrigin());
            }
            distances.Sort();
            // Skipping first value of 0 for origin point
            return distances[1];
        }

        private List<Point2D> CalculatePoints(List<string> instructions)
        {
            List<Point2D> points = new List<Point2D>();
            Point2D currentPoint = new Point2D(0, 0);
            points.Add(new Point2D(currentPoint));
            foreach (string inst in instructions)
            {
                char direction = inst[0];
                int distance = int.Parse(inst.Substring(1));
                switch (direction)
                {
                    case 'U':
                        for (int d = distance; d > 0; d--)
                        {
                            points.Add(new Point2D(currentPoint.UpdateIncremental(0, 1)));
                        }
                        break;
                    case 'D':
                        for (int d = distance; d > 0; d--)
                        {
                            points.Add(new Point2D(currentPoint.UpdateIncremental(0, -1)));
                        }
                        break;
                    case 'R':
                        for (int d = distance; d > 0; d--)
                        {
                            points.Add(new Point2D(currentPoint.UpdateIncremental(1, 0)));
                        }
                        break;
                    case 'L':
                        for (int d = distance; d > 0; d--)
                        {
                            points.Add(new Point2D(currentPoint.UpdateIncremental(-1, 0)));
                        }
                        break;
                    default:
                        throw new InvalidOperationException($"Direction '{direction}' is undefined.");
                }
            }
            return points;
        }
    }
}