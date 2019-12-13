﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day5 : IAdventOfCodeProblem
    {
        private readonly string problemUrl = "https://adventofcode.com/2019/day/5";
        private readonly string problemTitle = "Day 5: Sunny with a Chance of Asteroids";
        private readonly string fileName = "D5P1.txt";
        private InputGetter inputGetter;
        private string rawInput;
        private IntcodeComputer computer;

        public Day5()
        {
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(fileName);
            computer = new IntcodeComputer(rawInput);
        }

        public string FileName() => fileName;

        public string ProblemTitle() => problemTitle;

        public string ProblemUrl() => problemUrl;

        public int SolvePart1()
        {
            computer.ComputeOpcodes(null, null, (int)SystemId.AirConditioner);
            return computer.Output[computer.Output.Count - 1];
        }

        public int SolvePart2()
        {
            computer.ComputeOpcodes(null, null, (int)SystemId.ThermalRadiators);
            return computer.Output[computer.Output.Count - 1];
        }
    }
}