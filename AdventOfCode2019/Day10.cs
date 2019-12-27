using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Mehroz;

namespace AdventOfCode2019
{
    class Day10 : IAdventOfCodeProblem
    {
        private readonly string _problemUrl = "https://adventofcode.com/2019/day/10";
        private readonly string _problemTitle = "Day 10: Monitoring Station";
        private readonly string _fileName = "D10P1.txt";
        private InputGetter _inputGetter;
        private readonly string _rawInput;
        public List<Point> CoordinateMap { get; private set; }
        public int mapSizeX { get; private set; } = 0;
        public int mapSizeY { get; private set; } = 0;

        public Day10()
        {            
            _inputGetter = new InputGetter();
            //_rawInput = _inputGetter.GetRawString(_fileName);
            _rawInput = @".#..#
.....
#####
....#
...##";
            CoordinateMap = new List<Point>();
            PopulateMap();
            Console.WriteLine(string.Join(",", CoordinateMap));
        }

        private void PopulateMap(char marker = '#')
        {
            if (CoordinateMap.Any())
                CoordinateMap = new List<Point>();
            //Console.WriteLine(_rawInput);
            string[] rows = _rawInput.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            mapSizeX = rows[0].Length;
            mapSizeY = rows.Length;
            //Console.WriteLine($"Size: X={mapSizeX}, Y={mapSizeY}");
            for (int y = 0; y < mapSizeY; y++)
                for (int x = 0; x < mapSizeX; x++)
                    if (rows[y][x] == marker)
                        CoordinateMap.Add(new Point(x, y));
        }

        public string FileName() => _fileName;

        public string ProblemTitle() => _problemTitle;

        public string ProblemUrl() => _problemUrl;

        public object SolvePart1()
        {
            int maxVisiblePoints = 0;
            foreach (Point point in CoordinateMap)
            {
                List<Point> visiblePoints = GetVisiblePoints(point);
                if (visiblePoints.Count > maxVisiblePoints)
                    maxVisiblePoints = visiblePoints.Count;
                Console.WriteLine($"Point: {point} | Visible: {visiblePoints.Count}");
                Console.WriteLine(string.Join(" / ", visiblePoints));
            }
            return maxVisiblePoints;
        }

        private List<Point> GetVisiblePoints(Point origin)
        {
            List<Point> visiblePoints = new List<Point>();
            foreach (Point target in CoordinateMap)
            {
                if (target != origin)
                {
                    if (PointIsVisible(origin, target))
                        visiblePoints.Add(target);
                }                    
            }
            return visiblePoints;
        }

        private bool PointIsVisible(Point origin, Point target)
        {
            Fraction slope;
            bool slopeIsUndefined = false;
            int deltaX = target.X - origin.X;
            int deltaY = target.Y - origin.Y;
            if (deltaX == 0)
            {
                slopeIsUndefined = true;
                slope = new Fraction();
            }                
            else if (deltaY == 0)
                slope = new Fraction();
            else
                slope = new Fraction(deltaY, deltaX);

            bool negativeDirection = false;
            // Check UP-DOWN direction when deniminator is 0
            if (slopeIsUndefined)
                if (target.Y < origin.Y)
                    negativeDirection = true;
            // Check LEFT-RIGHT direction when numerator is 0
            if (slope.Numerator == 0 && target.X < origin.X)
                negativeDirection = true;
            Console.WriteLine($"origin: {origin} | target: {target} | slope: {slope} neg: {negativeDirection}");

            // Handling for straight vertical slope
            if (slopeIsUndefined)
            {
                // Note: Negative Y direction visually goes UP on the input grid, since the top-left corner is (0,0)
                if (negativeDirection)
                {
                    // Move upwards one Y at a time
                    for (int y = origin.Y - 1; y >= target.Y; y--)
                    {
                        Point currentPoint = new Point(origin.X, y);
                        // Check if this point exists in the map
                        if (CoordinateMap.Contains(currentPoint))
                        {
                            // If we find our target point first, then it is visible
                            if (currentPoint.Equals(target))
                            {
                                //Console.WriteLine($"target {target} is visible to origin {origin}");
                                return true;
                            }                                
                            else
                            {
                                //Console.WriteLine($"{target} is not visible to {origin}, blocked by {currentPoint}");
                                return false;
                            }                                
                        }
                    }
                    throw new InvalidProgramException($"Failed to process with origin: {origin} | target: {target}");
                }
                // Note: Negative Y direction visually goes DOWN on the input grid, since the top-left corner is (0,0)
                else
                {
                    for (int y = origin.Y + 1; y <= target.Y; y++)
                    {
                        Point currentPoint = new Point(origin.X, y);
                        if (CoordinateMap.Contains(currentPoint))
                        {
                            // If we find our target point first, then it is visible
                            if (currentPoint.Equals(target))
                            {
                                //Console.WriteLine($"target {target} is visible to origin {origin}");
                                return true;
                            }
                            else
                            {
                                //Console.WriteLine($"{target} is not visible to {origin}, blocked by {currentPoint}");
                                return false;
                            }
                        }
                    }
                    throw new InvalidProgramException($"Failed to process with origin: {origin} | target: {target}");
                }
            }

            // Handling for straight horizontal slope
            if (slope == 0)
            {
                if (negativeDirection)
                {
                    for (int x = origin.X - 1; x >= target.X; x--)
                    {
                        Point currentPoint = new Point(x, origin.Y);
                        if (CoordinateMap.Contains(currentPoint))
                        {
                            if (currentPoint.Equals(target))
                            {
                                Console.WriteLine($"target {target} is visible to origin {origin}");
                                return true;
                            }
                            else
                            {
                                Console.WriteLine($"{target} is not visible to {origin}, blocked by {currentPoint}");
                                return false;
                            }
                        }
                    }
                    throw new InvalidProgramException($"Failed to process with origin: {origin} | target: {target}");
                }
                else
                {
                    for (int x = origin.X + 1; x <= target.X; x++)
                    {
                        Point currentPoint = new Point(x, origin.Y);
                        if (CoordinateMap.Contains(currentPoint))
                        {
                            if (currentPoint.Equals(target))
                            {
                                Console.WriteLine($"target {target} is visible to origin {origin}");
                                return true;
                            }
                            else
                            {
                                Console.WriteLine($"{target} is not visible to {origin}, blocked by {currentPoint}");
                                return false;
                            }
                        }
                    }
                    throw new InvalidProgramException($"Failed to process with origin: {origin} | target: {target}");
                }
            }

            // Handling for all other slope values, using point-slope graphing method
            

            return false;
        }

        private Fraction GetSlope(Point origin, Point target)
        {
            int deltaX = target.X - origin.X;
            int deltaY = target.Y - origin.Y;
            if (deltaX == 0)
                return null;
            return new Fraction(deltaY, deltaX);
            //return (Decimal)deltaY / deltaX;
        }

        private Point[] Sort2Points(Point a, Point b)
        {
            if (a.X + a.Y > b.X + b.Y)
                return new Point[] { a, b };
            return new Point[] { b, a };
        }

        private static int GCD(int a, int b) => a == 0 ? b : GCD(b % a, a);

        public object SolvePart2()
        {
            return -1;
        }
    }
}
