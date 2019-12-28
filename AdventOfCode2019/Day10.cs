﻿using System;
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
            _rawInput = _inputGetter.GetRawString(_fileName);
            CoordinateMap = new List<Point>();
            PopulateMap();
            Console.WriteLine(string.Join(",", CoordinateMap));
        }

        private void PopulateMap(char marker = '#')
        {
            if (CoordinateMap.Any())
                CoordinateMap = new List<Point>();
            string[] rows = _rawInput.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            mapSizeX = rows[0].Length;
            mapSizeY = rows.Length;
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
                //Console.WriteLine($"Point: {point} | Visible: {visiblePoints.Count}");
                //Console.WriteLine(string.Join(" / ", visiblePoints));
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

            // Test for purely vertical slope
            if (deltaX == 0)
            {
                slopeIsUndefined = true;
                // This slope value will be ignored, but needs assigned so the program compiles
                slope = new Fraction();
            }
            // Test for purely horizontal slope
            else if (deltaY == 0)
                // This slope value will be ignored, but needs assigned so the program compiles
                slope = new Fraction();
            // Any other slope
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

            //Console.WriteLine($"origin: {origin} | target: {target} | deltaX={deltaX} deltaY={deltaY} | slope: {slope.ToString()} neg: {negativeDirection}");

            // Handling for straight vertical slope
            if (slopeIsUndefined)
            {
                // Note: Negative Y direction visually goes UP on the input grid, since the top-left corner is (0,0)
                if (negativeDirection)
                {
                    for (int y = origin.Y - 1; y >= target.Y; y--)
                    {
                        Point currentPoint = new Point(origin.X, y);
                        if (CoordinateMap.Contains(currentPoint))
                        {
                            if (currentPoint.Equals(target))
                            {
                                return true;
                            }                                
                            else
                            {
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
                            if (currentPoint.Equals(target))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            // Handling for straight horizontal slope
            if (slope.Numerator == 0)
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
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
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
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            // Handling for all other slope values
            bool endLoop = false;
            long runningX = origin.X;
            long runningY = origin.Y;
            while (!endLoop)
            {
                runningX += slope.Denominator;
                runningY += slope.Numerator;

                Point currentPoint = new Point((int)runningX, (int)runningY);
                if (CoordinateMap.Contains(currentPoint))
                {
                    if (currentPoint.Equals(target))
                    {
                        endLoop = true;
                        return true;
                    }
                    else
                    {
                        endLoop = true;
                        return false;
                    }
                }
            }
            throw new InvalidProgramException($"Failed to find visible point with origin: {origin} | target: {target}");
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
