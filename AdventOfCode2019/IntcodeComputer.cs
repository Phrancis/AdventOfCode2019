using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    class IntcodeComputer
    {
        public List<int> InitialMemory { get; private set; }
        public List<int> WorkingMemory { get; private set; }
        public List<int> Output { get; private set; }

        public IntcodeComputer(List<int> memoryList)
        {
            InitialMemory = memoryList;
            WorkingMemory = new List<int>(InitialMemory);
            Output = new List<int>();
        }

        public IntcodeComputer(string rawMemory, char separator = ',')
        {
            InitialMemory = new List<int>();
            foreach (string item in rawMemory.Split(separator))
            {
                InitialMemory.Add(Int32.Parse(item));
            }
            WorkingMemory = new List<int>(InitialMemory);
        }

        public void ResetToInitialMemory() => WorkingMemory = new List<int>(InitialMemory);

        public List<int> ComputeOpcodes(int? noun = null, int? verb = null, int? userInput = null)
        {
            ResetToInitialMemory();
            Output = new List<int>();
            if (noun != null)
                WorkingMemory[1] = (int)noun;
            if (verb != null)
                WorkingMemory[2] = (int)verb;

            bool programEnded = false;
            int ptr = 0;
            int instructionLength;

            while (!programEnded)
            {
                int opcodeInput = WorkingMemory[ptr];
                List<OpcodeParameterMode> modes = new List<OpcodeParameterMode>();
                Opcode opcode;

                //Console.WriteLine($"{Environment.NewLine}-- INSTRUCTION --");
                //Console.WriteLine($"opcodeInput: {opcodeInput}");

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
                    foreach (char m in operands[1].ToCharArray())
                    {
                        modes.Add((OpcodeParameterMode)int.Parse(m.ToString()));
                    }
                    //Console.WriteLine($"Opcode: {opcode} | Operands: {operands[1]}");
                }
                
                List<int> instruction = new List<int>();
                //Console.WriteLine($"Modes:");
                //Console.WriteLine(modes.Count > 0 ? string.Join(",", modes) : "none");

                switch (opcode)
                {
                    case Opcode.Halt:
                        instructionLength = 1;
                        programEnded = true;
                        break;
                    case Opcode.Add:
                        instructionLength = 4;
                        instruction = WorkingMemory.GetRange(ptr, instructionLength);
                        //Console.WriteLine("Instruction:");
                        //Console.WriteLine(string.Join(",", instruction));
                        int add1, add2, addLocationToUpdate;
                        if (modes.Count == 0)
                        {
                            add1 = WorkingMemory[instruction[1]];
                            add2 = WorkingMemory[instruction[2]];
                            addLocationToUpdate = instruction[3];
                        }
                        else
                        {
                            List<int> values = new List<int>();
                            modes.Reverse();
                            for (int m = 0; m < modes.Count; m++)
                            {
                                OpcodeParameterMode mode = modes[m];
                                switch (mode)
                                {
                                    case OpcodeParameterMode.Position:
                                        values.Add(WorkingMemory[instruction[m + 1]]);
                                        break;
                                    case OpcodeParameterMode.Value:
                                        values.Add(instruction[m + 1]);
                                        break;
                                    default:
                                        throw new InvalidOperationException($"OpcodeParameterMode ID '{modes[m]}' is not valid.");
                                }
                            }
                            //Console.WriteLine("Values:");
                            //Console.WriteLine(string.Join(",", values));
                            add1 = values[0];
                            add2 = values[1];
                            addLocationToUpdate = instruction[3];
                        }
                        WorkingMemory[addLocationToUpdate] = add1 + add2;
                        //Console.WriteLine($"{opcode}: Memory location {addLocationToUpdate} updated to {WorkingMemory[addLocationToUpdate]}");
                        break;
                    case Opcode.Multiply:
                        instructionLength = 4;
                        instruction = WorkingMemory.GetRange(ptr, instructionLength);
                        //Console.WriteLine("Instruction:");
                        //Console.WriteLine(string.Join(",", instruction));
                        int mult1, mult2, multLocationToUpdate;
                        if (modes.Count == 0)
                        {
                            mult1 = WorkingMemory[instruction[1]];
                            mult2 = WorkingMemory[instruction[2]];
                            multLocationToUpdate = instruction[3];
                        }
                        else
                        {
                            List<int> values = new List<int>();
                            modes.Reverse();
                            for (int m = 0; m < modes.Count; m++)
                            {
                                OpcodeParameterMode mode = modes[m];
                                switch (mode)
                                {
                                    case OpcodeParameterMode.Position:
                                        values.Add(WorkingMemory[instruction[m + 1]]);
                                        break;
                                    case OpcodeParameterMode.Value:
                                        values.Add(instruction[m + 1]);
                                        break;
                                    default:
                                        throw new InvalidOperationException($"OpcodeParameterMode ID '{modes[m]}' is not valid.");
                                }
                            }
                            //Console.WriteLine("Values:");
                            //Console.WriteLine(string.Join(",", values));
                            mult1 = values[0];
                            mult2 = values[1];
                            multLocationToUpdate = instruction[3];
                        }
                        WorkingMemory[multLocationToUpdate] = mult1 * mult2;
                        //Console.WriteLine($"{opcode}: Memory location {multLocationToUpdate} updated to {WorkingMemory[multLocationToUpdate]}");
                        break;
                    case Opcode.Get:
                        instructionLength = 2;
                        int locationToUpdate = WorkingMemory[ptr + 1];
                        if (userInput != null)
                            WorkingMemory[locationToUpdate] = (int)userInput;
                        else
                            throw new InvalidOperationException($"Opcode Get was called, but user input was null.");
                        //Console.WriteLine($"Get instruction updated location {locationToUpdate} to {WorkingMemory[locationToUpdate]}");
                        break;
                    case Opcode.Output:
                        instructionLength = 2;
                        int outputParam = WorkingMemory[ptr + 1];
                        int outputValue;
                        if (modes.Count == 0)
                        {
                            outputValue = WorkingMemory[outputParam];
                        }
                        else
                        {
                            modes.Reverse();
                            switch (modes[0])
                            {
                                case OpcodeParameterMode.Position:
                                    outputValue = WorkingMemory[outputParam];
                                    break;
                                case OpcodeParameterMode.Value:
                                    outputValue = outputParam;
                                    break;
                                default:
                                    throw new InvalidOperationException($"OpcodeParameterMode ID '{modes[0]}' is not valid.");
                            }
                        }
                        //Console.WriteLine($"{opcode}: outputIndex: {outputParam} | outputValue: {outputValue}");
                        Output.Add(outputValue);
                        break;
                    case Opcode.JumpIfTrue:
                        instructionLength = 3;
                        instruction = WorkingMemory.GetRange(ptr, instructionLength);
                        //Console.WriteLine("Instruction:");
                        //Console.WriteLine(string.Join(",", instruction));
                        int jumpIfTrueParam1, jumpIfTrueParam2;
                        if(modes.Count == 0)
                        {
                            jumpIfTrueParam1 = WorkingMemory[instruction[1]];
                            jumpIfTrueParam2 = WorkingMemory[instruction[2]];
                        }
                        else
                        {
                            modes.Reverse();
                            if (modes[0] == OpcodeParameterMode.Position)
                                jumpIfTrueParam1 = WorkingMemory[instruction[1]];
                            else
                                jumpIfTrueParam1 = instruction[1];
                            if (modes[1] == OpcodeParameterMode.Position)
                                jumpIfTrueParam2 = WorkingMemory[instruction[2]];
                            else
                                jumpIfTrueParam2 = instruction[2];
                        }
                        if (jumpIfTrueParam1 != 0)
                        {
                            ptr = jumpIfTrueParam2;
                            instructionLength = 0;
                        }
                        //Console.WriteLine($"{opcode}: Param1: {jumpIfTrueParam1} | Param2: {jumpIfTrueParam2} | Pointer: {ptr}");
                        break;
                    case Opcode.JumpIfFalse:
                        instructionLength = 3;
                        instruction = WorkingMemory.GetRange(ptr, instructionLength);
                        //Console.WriteLine("Instruction:");
                        //Console.WriteLine(string.Join(",", instruction));
                        int jumpIfFalseParam1, jumpIfFalseParam2;
                        if (modes.Count == 0)
                        {
                            jumpIfFalseParam1 = WorkingMemory[instruction[1]];
                            jumpIfFalseParam2 = WorkingMemory[instruction[2]];
                        }
                        else
                        {
                            modes.Reverse();
                            if (modes[0] == OpcodeParameterMode.Position)
                                jumpIfFalseParam1 = WorkingMemory[instruction[1]];
                            else
                                jumpIfFalseParam1 = instruction[1];
                            if (modes[1] == OpcodeParameterMode.Position)
                                jumpIfFalseParam2 = WorkingMemory[instruction[2]];
                            else
                                jumpIfFalseParam2 = instruction[2];
                        }
                        if (jumpIfFalseParam1 == 0)
                        {
                            ptr = jumpIfFalseParam2;
                            instructionLength = 0;
                        }
                        //Console.WriteLine($"{opcode}: Param1: {jumpIfFalseParam1} | Param2: {jumpIfFalseParam2} | Pointer: {ptr}");
                        break;
                    case Opcode.LessThan:
                        instructionLength = 4;
                        instruction = WorkingMemory.GetRange(ptr, instructionLength);
                        //Console.WriteLine("Instruction:");
                        //Console.WriteLine(string.Join(",", instruction));
                        int lessThanParam1, lessThanParam2;
                        if (modes.Count == 0)
                        {
                            lessThanParam1 = WorkingMemory[instruction[1]];
                            lessThanParam2 = WorkingMemory[instruction[2]];
                        }
                        else
                        {
                            modes.Reverse();
                            lessThanParam1 = modes[0] == OpcodeParameterMode.Position
                                ? WorkingMemory[instruction[1]]
                                : instruction[1];
                            lessThanParam2 = modes[1] == OpcodeParameterMode.Position
                                ? WorkingMemory[instruction[2]]
                                : instruction[2];
                        }
                        WorkingMemory[instruction[3]] = lessThanParam1 < lessThanParam2 ? 1 : 0;
                        //Console.WriteLine($"{opcode}: Param1: {lessThanParam1} | Param2: {lessThanParam2} | Location updated: {instruction[3]}");
                        break;
                    case Opcode.Equals:
                        instructionLength = 4;
                        instruction = WorkingMemory.GetRange(ptr, instructionLength);
                        //Console.WriteLine("Instruction:");
                        //Console.WriteLine(string.Join(",", instruction));
                        int equalsParam1, equalsParam2;
                        if (modes.Count == 0)
                        {
                            equalsParam1 = WorkingMemory[instruction[1]];
                            equalsParam2 = WorkingMemory[instruction[2]];
                        }
                        else
                        {
                            modes.Reverse();
                            equalsParam1 = modes[0] == OpcodeParameterMode.Position
                                ? WorkingMemory[instruction[1]]
                                : instruction[1];
                            equalsParam2 = modes[1] == OpcodeParameterMode.Position
                                ? WorkingMemory[instruction[2]]
                                : instruction[2];
                        }
                        WorkingMemory[instruction[3]] = equalsParam1 == equalsParam2 ? 1 : 0;
                        //Console.WriteLine($"{opcode}: Param1: {equalsParam1} | Param2: {equalsParam2} | Location updated: {instruction[3]}");
                        break;
                    default:
                        throw new InvalidOperationException($"Operation # {(int)opcode} is not a valid Opcode.");
                }
                ptr += instructionLength;
            }
            return WorkingMemory;
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