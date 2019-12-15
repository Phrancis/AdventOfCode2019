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
        private bool _programHalted = false;

        public Day7()
        {
            _inputGetter = new InputGetter();
            _rawInput = _inputGetter.GetRawString(_fileName);
        }

        public string FileName() => _fileName;

        public string ProblemTitle() => _problemTitle;

        public string ProblemUrl() => _problemUrl;

        public object SolvePart1()
        {
            List<int> phaseSettings = new List<int>(new int[] { 0, 1, 2, 3, 4 });
            IEnumerable<IEnumerable<int>> phaseCombos = GetPermutations(phaseSettings, phaseSettings.Count);
            List<int> outputs = new List<int>();
            foreach (IEnumerable<int> combo in phaseCombos)
            {
                outputs.Add(ProcessAmplifierControllerProgram(combo));
            }
            return outputs.Max();
        }

        public object SolvePart2()
        {
            List<int> phaseSettings = new List<int>(new int[] { 5, 6, 7, 8, 9 });
            IEnumerable<IEnumerable<int>> phaseCombos = GetPermutations(phaseSettings, phaseSettings.Count);
            List<int> outputs = new List<int>();
            foreach (IEnumerable<int> combo in phaseCombos)
            {
                outputs.Add(ProcessAmplifierControllerProgramWithFeedbackLoop(combo));
            }
            Console.WriteLine("-- OUTPUTS --");
            Console.WriteLine(string.Join(",", outputs));
            return outputs.Max();
        }

        private int ProcessAmplifierControllerProgram(IEnumerable<int> phaseSettings)
        {
            IntcodeComputer computer = new IntcodeComputer(_rawInput);
            int output = 0;
            int[] inputs;
            foreach (int setting in phaseSettings)
            {
                inputs = new int[] { setting, output };
                computer.ComputeOpcodes(null, null, inputs);
                output = computer.Output[0];
            }
            return output;
        }

        private int ProcessAmplifierControllerProgramWithFeedbackLoop(IEnumerable<int> phaseSettings)
        {
            List<IntcodeComputer> computers = new List<IntcodeComputer>();
            // Make enough independent computers
            for (int i = 0; i < phaseSettings.Count(); i++)
                computers.Add(new IntcodeComputer(_rawInput));
            // Listener for the last computer's Halt Intcode command
            computers[computers.Count - 1].OnProgramHalted += ProgramHalted;
            // Out/In signals to pass from one computer to the next
            // Note: Initialize with last signal as 0 so it is passed to the very 1st computer loop
            int?[] signals = new int?[] { null, null, null, null, 0 };
            // Control data flow in the 1st fun of each computer
            int rounds = 0;
            bool firstRoundDone = false;
            // Run the main loop until a Halt Intcode is processed by the last computer
            _programHalted = false;
            while (!_programHalted)
            {
                for (int i = 0; i < computers.Count; i++)
                {
                    // New inputs from last computer's output
                    int[] computerInputs;
                    int signalIdx = i == 0 ? signals.Length - 1 : i - 1;
                    if (!firstRoundDone)
                        computerInputs = new int[] { phaseSettings.ToList()[i], (int)signals[signalIdx] };
                    else
                        computerInputs = new int[] { (int)signals[signalIdx] };
                    // Process without resetting computer
                    computers[i].ComputeOpcodes(null, null, computerInputs, false);
                    // Last item of this computer's output list to be passed to next computer
                    signals[i] = computers[i].Output[computers[i].Output.Count - 1];
                    signals[signalIdx] = null;
                    rounds++;
                    if (rounds == computers.Count)
                        firstRoundDone = true;
                }
            }
            // The  last value of the final computer's output is what would get sent to the ship's thrusters
            return computers[computers.Count - 1].Output[computers[computers.Count - 1].Output.Count - 1];
        }

        // Source — https://stackoverflow.com/a/10630026/3626537
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        private void ProgramHalted(object sender, EventArgs e)
        {
            _programHalted = true;
        }
    }
}
