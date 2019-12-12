using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    class Day1Problem2 : IAdventOfCodeProblem
    {
        private readonly string problemUrl = "https://adventofcode.com/2019/day/1#part2";
        private readonly string problemTitle = "Day 1: The Tyranny of the Rocket Equation - Part 2";
        private readonly string fileName = "D1P1.txt";
        private InputGetter inputGetter;
        private string rawInput;
        private Day1Problem1 d1p1;
        private List<int> fuelForModules;
        private List<int> fuelForFuel;

        public Day1Problem2()
        {
            d1p1 = new Day1Problem1();
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(fileName);
            fuelForModules = new List<int>();
            fuelForFuel = new List<int>();
        }

        public string ProblemUrl() => problemUrl;

        public string ProblemTitle() => problemTitle;

        public string FileName() => fileName;

        public int SolvePart1()
        {
            int totalFuelMass = 0;
            List<string> modulesMass = rawInput.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            foreach (string mass in modulesMass)
            {
                int fuel = d1p1.CalculateFuel(Int32.Parse(mass));
                fuelForModules.Add(fuel);
                totalFuelMass += fuel;
            }
            foreach (int mass in fuelForModules)
            {
                int fuel = CalculateFuelForFuel(mass);
                fuelForFuel.Add(fuel);
                totalFuelMass += fuel;
            }
            return totalFuelMass;
        }

        public int SolvePart2()
        {
            return -1;
        }

        public int CalculateFuelForFuel(int fuelMass)
        {
            int cumulativeFuel = 0;
            int fuelToAdd = d1p1.CalculateFuel(fuelMass);
            while (fuelToAdd > 0)
            {
                cumulativeFuel += fuelToAdd;
                fuelToAdd = d1p1.CalculateFuel(fuelToAdd);
            }
            return cumulativeFuel;
        }
    }
}
