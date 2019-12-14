using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day8 : IAdventOfCodeProblem
    {
        private readonly string _problemUrl = "https://adventofcode.com/2019/day/8";
        private readonly string _problemTitle = "Day 8: Space Image Format";
        private readonly string _fileName = "D8P1.txt";
        private InputGetter _inputGetter;
        private readonly string _rawInput;

        public Day8()
        {
            _inputGetter = new InputGetter();
            _rawInput = _inputGetter.GetRawString(_fileName);
        }

        public string FileName() => _fileName;

        public string ProblemTitle() => _problemTitle;

        public string ProblemUrl() => _problemUrl;

        public int SolvePart1()
        {
            int width = 25;
            int height = 6;
            IEnumerable<IEnumerable<string>> imagePixels = ParseEncodedImage(_rawInput, width, height);
            int lowestNumOfZeroes = int.MaxValue;
            List<string> layerWithFewestZeroes = new List<string>();
            foreach (List<string> layer in imagePixels)
            {
                int numOfZeroes = CountCharInStringList('0', layer);
                if (numOfZeroes < lowestNumOfZeroes)
                {
                    layerWithFewestZeroes = layer;
                    lowestNumOfZeroes = numOfZeroes;
                }                    
            }
            return CountCharInStringList('1', layerWithFewestZeroes) * CountCharInStringList('2', layerWithFewestZeroes);
        }

        /// <summary>
        /// Counts the total number of instances of a character within a list of strings.
        /// </summary>
        /// <param name="ch">The character to count</param>
        /// <param name="list">The list of strings to count from</param>
        /// <returns></returns>
        private static int CountCharInStringList(char ch, List<string> list)
        {
            int numOfChars = 0;
            foreach (string str in list)
                foreach (char c in str)
                    if (c == ch)
                        numOfChars++;
            return numOfChars;
        }

        /// <summary>
        /// Parses a raw input string (encoded image) into an IEnumerable of layers of values representing it.
        /// </summary>
        /// <param name="input">The encoded image as a string</param>
        /// <param name="width">The width of individual values</param>
        /// <param name="height">The number of values per layer</param>
        /// <returns></returns>
        private static IEnumerable<IEnumerable<string>> ParseEncodedImage(string input, int width, int height)
        {
            return ChunkList(ChunkString(input, width), height);
        }

        /// <summary>
        /// Split a string into chunks of a certain length.
        /// Source — https://stackoverflow.com/a/1450889/3626537
        /// </summary>
        /// <param name="input">The string to chunk</param>
        /// <param name="chunkSize">The size of each chunk</param>
        /// <returns>A list of the split chunks</returns>
        public static IEnumerable<string> ChunkString(string input, int chunkSize)
        {
            for (int i = 0; i < input.Length; i += chunkSize)
                yield return input.Substring(i, chunkSize);
        }

        /// <summary>
        /// Chunk an IEnumerable into a list of IEnumerable of a certain size.
        /// Source — https://stackoverflow.com/a/30248074/3626537
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerable</typeparam>
        /// <param name="input">The IEnumerable to chunk</param>
        /// <param name="size">The size of the chunks (in number of elements)</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> ChunkList<T>(IEnumerable<T> input, int size)
        {
            var list = new List<List<T>>();
            List<T> sourceAsList = input.ToList();
            for (int i = 0; i < sourceAsList.Count; i += size)
                yield return sourceAsList.GetRange(i, Math.Min(size, sourceAsList.Count - i));
        }

        public int SolvePart2()
        {
            return -1;
        }
    }
}
