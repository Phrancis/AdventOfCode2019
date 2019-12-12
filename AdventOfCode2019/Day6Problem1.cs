using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fileName">The name of the text file to use for input</param>
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

        public void PopulateMap()
        {
            string[] orbits = _rawInput.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string s in orbits)
            {
                _orbitMap.ProcessMapEntry(s);
            }
        }

        /// <summary>
        /// Solve the problem.
        /// </summary>
        /// <returns>The solution to the problem</returns>
        public int SolvePart1()
        {
            PopulateMap();
            return _orbitMap.CheckSum();
        }

        public int SolvePart2()
        {
            return new Day6Problem2().SolvePart1();
        }

        public class OrbitMap
        {
            public List<OrbitObject> OrbitingObjects { get; private set; }

            /// <summary>
            /// Constructor.
            /// </summary>
            public OrbitMap()
            {
                OrbitingObjects = new List<OrbitObject>();
            }

            /// <summary>
            /// Add an object to the objects in this map.
            /// </summary>
            /// <param name="obj">The OrbitObject to add</param>
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

            /// <summary>
            /// Find the head (top parent) object of this map.
            /// </summary>
            /// <returns>The head object</returns>
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
                    orbitedObj.AddChild(orbitingObj);
                }
            }

            /// <summary>
            /// Calculates the sum of the orbital distance from the head for each object in the map.
            /// </summary>
            /// <returns>The sum of all the distances</returns>
            public int CheckSum()
            {
                int checksum = 0;
                foreach (OrbitObject obj in OrbitingObjects)
                {
                    checksum += obj.OrbitDistanceToHead();
                }
                return checksum;
            }

            /// <summary>
            /// Calculates the distance in orbits between two objects, 
            /// i.e. the number of "jumps" for A to get in the same orbit as B, and vice versa.
            /// </summary>
            /// <param name="obj1">The 1st object</param>
            /// <param name="obj2">The 2nd object</param>
            /// <returns></returns>
            public int OrbitalJumpsBetween(OrbitObject obj1, OrbitObject obj2)
            {
                List<OrbitObject> obj1ToHead = obj1.ObjectsToHead();
                List<OrbitObject> obj2ToHead = obj2.ObjectsToHead();
                OrbitObject nearestObject = null;
                foreach (OrbitObject _obj1 in obj1ToHead)
                {
                    foreach (OrbitObject _obj2 in obj2ToHead)
                    {
                        if (_obj1 == _obj2)
                        {
                            nearestObject = _obj1;
                            break;
                        }                            
                    }
                    if (nearestObject != null)
                        break;
                }
                // This exception should never happen, because the head should be shared by all orbiting objects.
                if (nearestObject == null)
                    throw new InvalidOperationException($"Objects {obj1} and {obj2} do not orbit a shared object.");
                int obj1Distance = obj1ToHead.IndexOf(nearestObject) + 1;
                int obj2Distance = obj2ToHead.IndexOf(nearestObject)  + 1;
                return obj1Distance + obj2Distance;
            }

            public override string ToString()
            {
                string headStr = $"HEAD: {FindHead()} | ";
                string restStr = string.Join(" | ", OrbitingObjects);
                return string.Concat(headStr, restStr);
            }
        }

        public class OrbitObject : IEquatable<OrbitObject>
        {
            public string Name { get; private set; }
            public OrbitObject Parent { get; private set; }
            public List<OrbitObject> Children { get; private set; }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="name">The name of this object</param>
            /// <param name="parent">The parent object, or null if not known</param>
            public OrbitObject(string name, OrbitObject parent = null)
            {
                Name = name;
                Parent = parent;
                Children = new List<OrbitObject>();
            }

            /// <summary>
            /// Set this object's parent object (the object it's orbiting).
            /// </summary>
            /// <param name="parent">The parent object</param>
            public void SetParent(OrbitObject parent) => Parent = parent;

            /// <summary>
            /// Add an object as a child.
            /// </summary>
            /// <param name="child">The object to add</param>
            public void AddChild(OrbitObject child) => Children.Add(child);

            /// <summary>
            /// Calculate the distance (in number of orbiting objects) between this object and the head.
            /// </summary>
            /// <returns>The distance</returns>
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

            /// <summary>
            /// Get list of objects this object is orbiting up to the head.
            /// </summary>
            /// <returns>The list of orbited objects</returns>
            public List<OrbitObject> ObjectsToHead()
            {
                List <OrbitObject> objectsToHead = new List<OrbitObject>();
                OrbitObject nextParent = Parent;
                while (nextParent != null)
                {
                    objectsToHead.Add(nextParent);
                    nextParent = nextParent.Parent;
                }
                return objectsToHead;
            }

            public override string ToString()
            {
                string parentName;
                try
                {
                    parentName = Parent.Name;
                }
                catch (NullReferenceException)
                {
                    parentName = "none";
                }
                return $"OrbitObject[Name={Name}, Parent={parentName}, Children={Children.Count}]";
            }

            public override bool Equals(object obj)
            {
                return obj is OrbitObject && Equals(obj);
            }

            public override int GetHashCode()
            {
                var hashCode = -512206829;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
                hashCode = hashCode * -1521134295 + EqualityComparer<OrbitObject>.Default.GetHashCode(Parent);
                return hashCode;
            }

            public bool Equals(OrbitObject other)
            {
                return Name == other.Name;
            }
        }
    }
}
