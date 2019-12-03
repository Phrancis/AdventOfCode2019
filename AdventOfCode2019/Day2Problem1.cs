using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2019
{
    class Day2Problem1
    {
        public readonly string ProblemUrl = "https://adventofcode.com/2019/day/2";
        public readonly string ProblemTitle = "Day 2: 1202 Program Alarm";
        public readonly string FileName = "D2P1.txt";
        private InputGetter inputGetter;
        private string rawInput;

        public Day2Problem1()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(FileName);
        }

        internal int SolveProblem()
        {
            List<int> inputs = new List<int>();
            foreach (string s in rawInput.Split(','))
            {
                inputs.Add(Int32.Parse(s));
            }
            // Special instructions for 1202 program
            inputs[1] = 12;
            inputs[2] = 2;
            List<int> results = ComputeIntcodes(inputs);
            Console.WriteLine(results[0]);
            return results[0];
        }

        private List<int> ComputeIntcodes(List<int> inputs)
        {
            bool programEnded = false;
            int i = 0;
            while (!programEnded)
            {
                int operation = inputs[i];
                // Code 99 indicates end of Intcode program
                if (operation == 99)
                {
                    programEnded = true;
                    break;
                }
                int value1 = inputs[inputs[i + 1]];
                int value2 = inputs[inputs[i + 2]];
                if (operation == 1)
                    inputs[inputs[i + 3]] = value1 + value2;
                else if (operation == 2)
                    inputs[inputs[i + 3]] = value1 * value2;
                else
                    throw new InvalidOperationException();
                i += 4;
            }
            return inputs;
        }
    }
}
