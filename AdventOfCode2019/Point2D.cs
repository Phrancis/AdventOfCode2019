using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Point2D : IEquatable<Point2D>, IEqualityComparer<Point2D>
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point2D(Point2D point)
        {
            X = point.X;
            Y = point.Y;
        }

        public Point2D UpdateIncremental(int x, int y)
        {
            X += x;
            Y += y;
            return this;
        }

        public Point2D UpdateAbsolute(int x, int y)
        {
            X = x;
            Y = y;
            return this;
        }

        public int DistanceFromOrigin()
        {
            return Math.Abs(X) + Math.Abs(Y);
        }

        public bool Equals(Point2D other)
        {
            return other != null &&
                   X == other.X &&
                   Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            var d = obj as Point2D;
            return d != null &&
                   X == d.X &&
                   Y == d.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"Point2D[{X},{Y}]";
        }

        public bool Equals(Point2D first, Point2D second)
        {
            return 
                first != null && 
                second != null &&
                first.X == second.X &&
                first.Y == second.Y;
        }

        public int GetHashCode(Point2D obj)
        {
            return GetHashCode();
        }
    }
}
