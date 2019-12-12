﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day6Problem1 : IAdventOfCodeProblem
    {
        private readonly string _problemUrl = "https://adventofcode.com/2019/day/6";
        private readonly string _problemTitle = "Day 6: Universal Orbit Map";
        private readonly string _fileName = "D6P1.txt";
        private InputGetter _inputGetter;
        private string _rawInput;
        private OrbitMap _orbitMap;

        public Day6Problem1(string fileName = null)
        {
            if (fileName != null)
                _fileName = fileName;
            _inputGetter = new InputGetter();
            _rawInput = _inputGetter.GetRawString(_fileName);
            _orbitMap = new OrbitMap();
        }

        public string FileName() => _fileName;

        public string ProblemTitle() => _problemTitle;

        public string ProblemUrl() => _problemUrl;

        public OrbitMap GetOrbitMap() => _orbitMap;

        public int SolveProblem()
        {
            string[] orbits = _rawInput.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string s in orbits)
            {
                _orbitMap.ProcessMapEntry(s);
            }
            Console.WriteLine(_orbitMap);
            return _orbitMap.CheckSum();
        }

        public class OrbitMap
        {
            public List<OrbitObject> OrbitingObjects { get; private set; }

            public OrbitMap()
            {
                OrbitingObjects = new List<OrbitObject>();
            }

            public void AddObject(OrbitObject obj) => OrbitingObjects.Add(obj);

            public OrbitObject FindOrbitingObject(string name)
            {
                foreach (OrbitObject obj in OrbitingObjects)
                {
                    if (obj.Name == name)
                        return obj;
                }
                return null;
            }

            public OrbitObject FindHead()
            {
                foreach (OrbitObject obj in OrbitingObjects)
                {
                    if (obj.Parent == null)
                    {
                        return obj;
                    }
                }
                return null;
            }

            /// <summary>
            /// Takes a map entry like "FOO)BAR" and adds an OrbitObject named "BAR" to parent "FOO".
            /// - If "FOO" does not exist, it creates it.
            /// - If "BAR" exists, it makes "FOO" its parent node.
            /// - If "BAR" does not exist, it creates it, and sets "FOO" as its parent.
            /// </summary>
            /// <param name="entry">A map entry,e.g. "FOO)BAR"</param>
            /// <param name="delimiter">The character to use to split the values</param>
            public void ProcessMapEntry(string entry, char delimiter = ')')
            {
                string[] orbit = entry.Split(delimiter);
                string orbitedName = orbit[0];
                string orbitingName = orbit[1];
                OrbitObject orbitedObj = FindOrbitingObject(orbitedName);
                if (orbitedObj == null)
                {
                    orbitedObj = new OrbitObject(orbitedName);
                    AddObject(orbitedObj);
                }
                OrbitObject orbitingObj = FindOrbitingObject(orbitingName);
                if (orbitingObj != null)
                {
                    orbitingObj.SetParent(orbitedObj);
                    orbitedObj.AddChild(orbitingObj);
                }                    
                else
                {
                    orbitingObj = new OrbitObject(orbitingName, orbitedObj);
                    AddObject(orbitingObj);
                }
            }

            public int CheckSum()
            {
                int checksum = 0;
                foreach (OrbitObject obj in OrbitingObjects)
                {
                    checksum += obj.OrbitDistanceToHead();
                }
                return checksum;
            }

            public override string ToString()
            {
                string headStr = $"HEAD: {FindHead()} | ";
                string restStr = string.Join(" | ", OrbitingObjects);
                return string.Concat(headStr, restStr);
            }
        }

        public class OrbitObject
        {
            public string Name { get; private set; }
            public OrbitObject Parent { get; private set; }
            public List<OrbitObject> Children { get; private set; }

            public OrbitObject(string name, OrbitObject parent = null)
            {
                Name = name;
                Parent = parent;
                Children = new List<OrbitObject>();
            }

            public void SetParent(OrbitObject parent) => Parent = parent;

            public void AddChild(OrbitObject child) => Children.Add(child);

            public int OrbitDistanceToHead()
            {
                if (Parent == null)
                    return 0;
                int distance = 0;
                OrbitObject nextParent = Parent;
                while (nextParent != null)
                {
                    distance++;
                    nextParent = nextParent.Parent;
                }
                return distance;
            }

            public override string ToString()
            {
                //string parentName = Parent.Name != null ? Parent.Name : "none";
                string parentName;
                try
                {
                    parentName = Parent.Name;
                }
                catch (NullReferenceException e)
                {
                    parentName = "none";
                }
                return $"OrbitObject[Name={Name}, Parent={parentName}, Children={Children.Count}";
            }
        }
    }
}
