using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day9 : IAdventOfCodeProblem
    {
        private readonly string _problemUrl = "https://adventofcode.com/2019/day/9";
        private readonly string _problemTitle = "Day 9: Sensor Boost";
        private readonly string _fileName = "D9P1.txt";
        private InputGetter _inputGetter;
        private readonly string _rawInput;
        private readonly IntcodeComputer _computer;

        public string ProblemUrl() => _problemUrl;

        public string ProblemTitle() => _problemTitle;

        public string FileName() => _fileName;

        public Day9()
        {
            _inputGetter = new InputGetter();
            _rawInput = _inputGetter.GetRawString(_fileName);
            _computer = new IntcodeComputer(_rawInput);
        }

        public object SolvePart1()
        {
            _computer.ComputeOpcodes();
            Console.WriteLine(string.Join(",", _computer.Output));
            return "SKIPPED - NOT SOLVED";
        }

        public object SolvePart2()
        {
            return "SKIPPED - NOT SOLVED";
        }
    }
}
