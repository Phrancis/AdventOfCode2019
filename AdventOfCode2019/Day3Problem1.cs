using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    internal class Day3Problem1
    {
        public readonly string ProblemUrl = "https://adventofcode.com/2019/day/3";
        public readonly string ProblemTitle = "Day 3: Crossed Wires";
        public readonly string FileName = "D3P1.txt";
        private InputGetter inputGetter;
        private string rawInput;
        private List<string> wire1Data;
        private List<string> wire2Data;

        public Day3Problem1()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(FileName);
            string[] input = rawInput.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            wire1Data = new List<string>(input[0].Split(','));
            wire2Data = new List<string>(input[1].Split(','));
        }

        public int SolveProblem()
        {
            List<Point2D> wire1Points = CalculatePoints(wire1Data);
            List<Point2D> wire2Points = CalculatePoints(wire2Data);
            return 0;
        }

        private List<Point2D> CalculatePoints(List<string> directions)
        {
            List<Point2D> points = new List<Point2D>();

            return points;
        }
    }
}