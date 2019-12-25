using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
            for (int y = 0; y < mapSizeX; y++)
                for (int x = 0; x < mapSizeY; x++)
                    if (rows[y][x] == marker)
                        CoordinateMap.Add(new Point(x, y));
        }

        public string FileName() => _fileName;

        public string ProblemTitle() => _problemTitle;

        public string ProblemUrl() => _problemUrl;

        public object SolvePart1()
        {
            int maxVisiblePoints = 0;

            // SANITY CHECK
            Point point = new Point(4, 2);
            Console.WriteLine(point.Equals(new Point(4, 2)));

            //foreach (Point point in CoordinateMap)
            //{
            //    List<Point> visiblePoints = GetVisiblePoints(point);
            //    if (visiblePoints.Count > maxVisiblePoints)
            //        maxVisiblePoints = visiblePoints.Count;
            //    Console.WriteLine($"Point: {point} | Visible: {visiblePoints.Count}");
            //    Console.WriteLine(string.Join(" / ", visiblePoints));
            //}
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
            int distanceX = target.X - origin.X;
            int distanceY = target.Y - origin.Y;
            int intervalX = distanceX > 0 ? GCD(origin.X, distanceX) : -1 * GCD(origin.X, distanceX);
            int intervalY = distanceY > 0 ? GCD(origin.Y, distanceY) : -1 * GCD(origin.Y, distanceY);
            Console.WriteLine($"origin: {origin} | target: {target} | Distance: {distanceX}, {distanceY} | Interval: {intervalX}, {intervalY}");

            int runningX = origin.X + intervalX;
            int runningY = origin.Y + intervalY;

            while (runningX != target.X || runningY != target.Y)
            {
                foreach (Point point in CoordinateMap)
                {
                    Console.WriteLine($"point: {point} to match X={runningX},Y={runningY} -> {point.Equals(new Point(runningX, runningY))}");
                    if (point.Equals(new Point(runningX, runningY)))
                    {
                        if (point == target)
                            return true;
                        else
                            return false;
                    }
                        
                }

                runningX += intervalX;
                runningY += intervalY;
            }
            return false;
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
