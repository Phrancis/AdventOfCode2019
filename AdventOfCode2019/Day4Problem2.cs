using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day4Problem2 : IAdventOfCodeProblem
    {
        private readonly string problemUrl = "https://adventofcode.com/2019/day/4#part2";
        private readonly string problemTitle = "Day 4: Secure Container - Part 2";
        private readonly string fileName = "D4P1.txt";
        private Day4Problem1 d4p1;
        private List<int> initialQualifiedPassword;

        public Day4Problem2()
        {
            d4p1 = new Day4Problem1();
            d4p1.SolveProblem();
            initialQualifiedPassword = d4p1.QualifiedPasswords;
        }

        public string FileName() => fileName;

        public string ProblemTitle() => problemTitle;

        public string ProblemUrl() => problemUrl;

        public int SolveProblem()
        {
            List<int> newlyQualifiedPasswords = new List<int>();
            foreach (int password in initialQualifiedPassword)
            {
                int[] digits = d4p1.ConvertIntToDigits(password);
                if (Has2AdjacentDigitsNotPartOfAGroup(digits))
                {
                    newlyQualifiedPasswords.Add(password);
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, newlyQualifiedPasswords));
            return newlyQualifiedPasswords.Count;
        }

        private bool Has2AdjacentDigitsNotPartOfAGroup(int[] digits)
        {
            bool has2AdjacentDigitsNotPartOfAGroup = false;
            var groups = digits.GroupBy(d => d);
            foreach (var g in groups)
                if (g.Count() == 2)
                    has2AdjacentDigitsNotPartOfAGroup = true;
            return has2AdjacentDigitsNotPartOfAGroup;
        }
    }
}
