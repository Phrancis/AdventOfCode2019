using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day7 : IAdventOfCodeProblem
    {
        private readonly string _problemUrl = "https://adventofcode.com/2019/day/7";
        private readonly string _problemTitle = "Day 7: Amplification Circuit";
        private readonly string _fileName = "D7P1.txt";
        private InputGetter _inputGetter;
        private string _rawInput;
        private IntcodeComputer _computer;
        private readonly List<int> _phaseSettings;

        public Day7()
        {
            _inputGetter = new InputGetter();
            _rawInput = _inputGetter.GetRawString(_fileName);
            _computer = new IntcodeComputer(_rawInput);
            _phaseSettings = new List<int>(new int[] { 0,1,2,3,4 });
        }

        public string FileName() => _fileName;

        public string ProblemTitle() => _problemTitle;

        public string ProblemUrl() => _problemUrl;

        public int SolvePart1()
        {
            IEnumerable<IEnumerable<int>> phaseCombos = GetPermutations(_phaseSettings, _phaseSettings.Count);
            List<int> outputs = new List<int>();
            foreach (IEnumerable<int> combo in phaseCombos)
            {
                outputs.Add(ProcessAimplifierControllerProgram(combo));
            }
            return outputs.Max();
        }

        private int ProcessAimplifierControllerProgram(IEnumerable<int> phaseSettings)
        {
            int output = 0;
            int[] inputs;
            foreach (int setting in phaseSettings)
            {
                inputs = new int[] { setting, output };
                _computer.ComputeOpcodes(null, null, inputs);
                output = _computer.Output[0];
            }
            return output;
        }

        public int SolvePart2()
        {
            return -1;
        }

        // Source — https://stackoverflow.com/a/10630026/3626537
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
