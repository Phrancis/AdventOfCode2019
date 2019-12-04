using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Point2D
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
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
    }
}
