using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    class IntcodeComputer
    {
        public List<int> initialMemory { get; private set; }
        public List<int> workingMemory { get; private set; }

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

        public List<int> ComputeOpcodes(int? noun = null, int? verb = null, int? userInput = null)
        {
            ResetToInitialMemory();
            if (noun != null)
                workingMemory[1] = (int)noun;
            if (verb != null)
                workingMemory[2] = (int)verb;

            bool programEnded = false;
            int ptr = 0;
            int instructionLength;

            while (!programEnded)
            {
                int opcodeInput = workingMemory[ptr];
                List<string> modes = new List<string>();
                Opcode opcode;

                Console.WriteLine($"opcodeInput: {opcodeInput}");

                // Handle <=2 digit input
                if (opcodeInput <= 99)
                {
                    opcode = (Opcode)opcodeInput;
                }
                // Handle longer input as string
                else
                {
                    List<string> operands = ParseOperands(opcodeInput);
                    opcode = (Opcode)int.Parse(operands[0]);
                    modes = operands[1].Split().ToList();
                    Console.WriteLine($"Opcode: {opcode} | Operands: {operands[1]}");
                }
                
                List<int> instruction;
                Console.WriteLine($"Modes:");
                foreach (string m in modes)
                    Console.WriteLine(m);

                switch (opcode)
                {
                    case Opcode.Halt:
                        instructionLength = 1;
                        programEnded = true;
                        break;
                    case Opcode.Add:
                        instructionLength = 4;
                        instruction = workingMemory.GetRange(ptr, instructionLength);
                        Console.WriteLine("Instruction:");
                        Console.WriteLine(string.Join(",", instruction));
                        int add1, add2, addLocationToUpdate;
                        if (modes.Count == 0)
                        {
                            add1 = workingMemory[instruction[1]];
                            add2 = workingMemory[instruction[2]];
                            addLocationToUpdate = instruction[3];
                        }
                        else
                        {
                            List<int> values = new List<int>();
                            char[] modeVals = modes[0].ToCharArray();
                            Console.WriteLine(string.Join(",", modeVals));
                            for (int m = 0; m < modeVals.Length; m++)
                            {
                                OpcodeParameterMode mode = (OpcodeParameterMode)int.Parse(modeVals[m].ToString());
                                switch (mode)
                                {
                                    case OpcodeParameterMode.Position:
                                        values.Add(workingMemory[instruction[m + 1]]);
                                        break;
                                    case OpcodeParameterMode.Value:
                                        values.Add(instruction[m + 1]);
                                        break;
                                    default:
                                        throw new InvalidOperationException($"OpcodeParameterMode ID '{modes[m]}' is not valid.");
                                }
                            }
                            Console.WriteLine(string.Join(",", values));
                            add1 = values[0];
                            add2 = values[1];
                            addLocationToUpdate = values[2];
                        }
                        workingMemory[addLocationToUpdate] = add1 + add2;
                        Console.WriteLine($"Memory location {addLocationToUpdate} updated to {workingMemory[addLocationToUpdate]}");
                        break;
                    case Opcode.Multiply:
                        instructionLength = 4;
                        instruction = workingMemory.GetRange(ptr + 1, instructionLength);
                        int mult1 = workingMemory[instruction[0]];
                        int mult2 = workingMemory[instruction[1]];
                        workingMemory[instruction[2]] = mult1 * mult2;
                        break;
                    case Opcode.Get:
                        instructionLength = 2;
                        int locationToUpdate = workingMemory[ptr + 1];
                        Console.WriteLine($"Get instruction operation to update: {locationToUpdate}");
                        if (userInput != null)
                            workingMemory[locationToUpdate] = (int)userInput;
                        else
                            throw new InvalidOperationException($"Opcode Get was called, but user input was null.");
                        Console.WriteLine($"Get instruction updated location {locationToUpdate} to {workingMemory[locationToUpdate]}");
                        break;
                    case Opcode.Put:
                        throw new NotImplementedException();
                        break;
                    default:
                        throw new InvalidOperationException($"Operation # {(int)opcode} is not a valid Opcode.");
                }
                ptr += instructionLength;
            }
            return workingMemory;
        }

        private List<string> ParseOperands(int input)
        {
            List<string> operands = new List<string>();
            string rawInput = input.ToString();
            operands.Add(int.Parse(rawInput.Substring(rawInput.Length - 2, 2)).ToString());
            string rest = rawInput.Substring(0, rawInput.Length - 2);
            rest = rest.PadLeft(3, '0');
            operands.Add(rest);
            return operands;
        }

        private bool ListIsEmpty(IEnumerable<object> list) => list == null || list.Any();
    }
}