using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    interface IAdventOfCodeProblem
    {
        string ProblemUrl();
        string ProblemTitle();
        string FileName();
        int SolveProblem();
    }
}
