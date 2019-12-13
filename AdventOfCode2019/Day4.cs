using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    class Day4 : IAdventOfCodeProblem
    {
        private readonly string problemUrl = "https://adventofcode.com/2019/day/4";
        private readonly string problemTitle = "Day 4: Secure Container";
        private readonly string fileName = "D4P1.txt";
        private InputGetter inputGetter;
        private string rawInput;
        public List<int> QualifiedPasswords { get; private set; }

        public Day4()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(fileName);
        }

        public string FileName() => fileName;

        public string ProblemTitle() => problemTitle;

        public string ProblemUrl() => problemUrl;

        public int SolvePart1()
        {
            string[] range = rawInput.Split('-');
            int rangeMin = int.Parse(range[0]);
            int rangeMax = int.Parse(range[1]);
            QualifiedPasswords = new List<int>();

            for (int password = rangeMin; password <= rangeMax; password++)
            {
                int[] digits = ConvertIntToDigits(password);
                if (AllDigitsIncreasing(digits) && HasSameAdjacentDigits(digits))                
                    QualifiedPasswords.Add(password);
            }
            return QualifiedPasswords.Count;
        }

        public int SolvePart2()
        {
            List<int> newlyQualifiedPasswords = new List<int>();
            foreach (int password in QualifiedPasswords)
            {
                int[] digits = ConvertIntToDigits(password);
                if (Has2AdjacentDigitsNotPartOfAGroup(digits))
                {
                    newlyQualifiedPasswords.Add(password);
                }
            }
            //Console.WriteLine(string.Join(Environment.NewLine, newlyQualifiedPasswords));
            return newlyQualifiedPasswords.Count;
        }

        public int[] ConvertIntToDigits(int number) => number.ToString().Select(d => int.Parse(d.ToString())).ToArray();

        private bool AllDigitsIncreasing(int[] digits)
        {
            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] > digits[i + 1])
                    return false;
            }
            return true;
        }

        public bool HasSameAdjacentDigits(int[] digits)
        {
            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] == digits[i + 1])
                    return true;
            }
            return false;
        }

        public bool Has2AdjacentDigitsNotPartOfAGroup(int[] digits)
        {
            return digits.GroupBy(d => d).Any(g => g.Count() == 2);
        }
    }
}
