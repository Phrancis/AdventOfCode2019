using System;
using System.Collections.Generic;

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
            int instructionLength;

            while (!programEnded)
            {
                Opcode opcode = (Opcode)workingMemory[ptr];
                List<int> instruction;

                switch (opcode)
                {
                    case Opcode.Halt:
                        instructionLength = 1;
                        programEnded = true;
                        break;
                    case Opcode.Add:
                        instructionLength = 4;
                        instruction = workingMemory.GetRange(ptr, instructionLength);
                        int add1 = workingMemory[instruction[1]];
                        int add2 = workingMemory[instruction[2]];
                        workingMemory[instruction[3]] = add1 + add2;
                        break;
                    case Opcode.Multiply:
                        instructionLength = 4;
                        instruction = workingMemory.GetRange(ptr, instructionLength);
                        int mult1 = workingMemory[instruction[1]];
                        int mult2 = workingMemory[instruction[2]];
                        workingMemory[instruction[3]] = mult1 * mult2;
                        break;
                    default:
                        throw new InvalidOperationException($"Operation # {opcode} is not a valid Opcode.");
                }
                ptr += instructionLength;
            }
            return workingMemory;
        }
    }
}