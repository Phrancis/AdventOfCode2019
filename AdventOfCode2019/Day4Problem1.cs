using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    class Day4Problem1 : IAdventOfCodeProblem
    {
        private readonly string problemUrl = "https://adventofcode.com/2019/day/4";
        private readonly string problemTitle = "Day 4: Secure Container";
        private readonly string fileName = "D4P1.txt";
        private InputGetter inputGetter;
        private string rawInput;

        public Day4Problem1()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(fileName);
        }

        public string FileName() => fileName;

        public string ProblemTitle() => problemTitle;

        public string ProblemUrl() => problemUrl;

        public int SolveProblem()
        {
            string[] range = rawInput.Split('-');
            int rangeMin = int.Parse(range[0]);
            int rangeMax = int.Parse(range[1]);
            List<int> qualifiedPasswords = new List<int>();

            for (int password = rangeMin; password <= rangeMax; password++)
            {
                int[] digits = ConvertIntToDigits(password);
                if (AllDigitsIncreasing(digits) && HasSameAdjacentDigits(digits))                
                    qualifiedPasswords.Add(password);
            }
            return qualifiedPasswords.Count;
        }

        private int[] ConvertIntToDigits(int number) => number.ToString().Select(d => int.Parse(d.ToString())).ToArray();

        private bool AllDigitsIncreasing(int[] digits)
        {
            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] > digits[i + 1])
                    return false;
            }
            return true;
        }

        private bool HasSameAdjacentDigits(int[] digits)
        {
            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] == digits[i + 1])
                    return true;
            }
            return false;
        }
    }
}
