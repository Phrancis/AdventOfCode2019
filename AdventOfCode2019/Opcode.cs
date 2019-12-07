using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    enum Opcode
    {
        Add = 1,
        Multiply = 2,
        SaveInputToPosition = 3,
        OutputValueAtPosition = 4,
        Halt = 99,
    }
}
