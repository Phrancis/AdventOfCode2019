using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    class Day1 :IAdventOfCodeProblem
    {
        private readonly string problemUrl = "https://adventofcode.com/2019/day/1";
        private readonly string problemTitle = "Day 1: The Tyranny of the Rocket Equation";
        private readonly string fileName = "D1P1.txt";
        private InputGetter inputGetter;
        private string rawInput;
        private List<int> fuelForModules;
        private List<int> fuelForFuel;

        public Day1()
        {
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
            List<string> inputs = rawInput.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            List<int> fuelCalculations = new List<int>();
            foreach (string input in inputs)
            {
                fuelCalculations.Add(CalculateFuel((Int32.Parse(input))));
            }
            int sum = 0;
            foreach (int unit in fuelCalculations)
            {
                sum += unit;
            }
            return sum;
        }

        public int SolvePart2()
        {
            int totalFuelMass = 0;
            List<string> modulesMass = rawInput.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            foreach (string mass in modulesMass)
            {
                int fuel = CalculateFuel(Int32.Parse(mass));
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

        public int CalculateFuel(int mass)
        {
            return (int)Math.Floor((double)mass / 3) - 2;
        }

        public int CalculateFuelForFuel(int fuelMass)
        {
            int cumulativeFuel = 0;
            int fuelToAdd = CalculateFuel(fuelMass);
            while (fuelToAdd > 0)
            {
                cumulativeFuel += fuelToAdd;
                fuelToAdd = CalculateFuel(fuelToAdd);
            }
            return cumulativeFuel;
        }
    }
}
