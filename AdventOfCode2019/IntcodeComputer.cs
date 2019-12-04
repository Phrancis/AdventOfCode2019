using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class IntcodeComputer
    {
        private readonly List<int> initialMemory;
        private List<int> workingMemory;

        public IntcodeComputer(List<int> memoryList)
        {
            initialMemory = memoryList;
            workingMemory = new List<int>(initialMemory);
        }

        public IntcodeComputer(string rawMemory, char separator = ',')
        {
            initialMemory = new List<int>();
            foreach (string item in rawMemory.Split(separator))
            {
                initialMemory.Add(Int32.Parse(item));
            }
            workingMemory = new List<int>(initialMemory);
        }

        public void ResetToInitialMemory() => workingMemory = new List<int>(initialMemory);

        public List<int> ComputeOpcodes(int noun = 0, int verb = 0)
        {
            ResetToInitialMemory();
            workingMemory[1] = noun;
            workingMemory[2] = verb;

            bool programEnded = false;
            int ptr = 0;
            while (!programEnded)
            {
                int operation = workingMemory[ptr];
                // Code 99 indicates end of Intcode program
                if (operation == 99)
                {
                    programEnded = true;
                    break;
                }
                int value1 = workingMemory[workingMemory[ptr + 1]];
                int value2 = workingMemory[workingMemory[ptr + 2]];
                if (operation == 1)
                    workingMemory[workingMemory[ptr + 3]] = value1 + value2;
                else if (operation == 2)
                    workingMemory[workingMemory[ptr + 3]] = value1 * value2;
                else
                    throw new InvalidOperationException($"Operation # {operation} is not a valid Opcode.");
                ptr += 4;
            }
            return workingMemory;
        }
    }
}