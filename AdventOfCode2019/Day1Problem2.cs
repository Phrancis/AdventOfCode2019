using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2019
{
    class Day1Problem2
    {
        public readonly string ProblemUrl = "https://adventofcode.com/2019/day/1#part2";
        public readonly string ProblemTitle = "Day 1: The Tyranny of the Rocket Equation - Part 2";
        public readonly string FileName = "D1P1.txt";
        private InputGetter inputGetter;
        private string rawInput;
        private Day1Problem1 d1p1;
        private List<int> fuelForModules;
        private List<int> fuelForFuel;

        public Day1Problem2()
        {
            d1p1 = new Day1Problem1();
            inputGetter = new InputGetter();
            rawInput = inputGetter.GetRawString(FileName);
            fuelForModules = new List<int>();
            fuelForFuel = new List<int>();
        }

        public int SolveProblem()
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
