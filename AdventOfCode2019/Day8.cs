using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Solve Day 8 Part 1.
        /// </summary>
        /// <returns>The result</returns>
        public object SolvePart1()
        {
            var width = 25;
            var height = 6;
            var imageData = ParseEncodedImage(_rawInput, width, height);
            var lowestNumOfZeroes = int.MaxValue;
            var layerWithFewestZeroes = new List<string>();
            foreach (List<string> layer in imageData)
            {
                var numOfZeroes = CountCharInStringList('0', layer);
                if (numOfZeroes < lowestNumOfZeroes)
                {
                    layerWithFewestZeroes = layer;
                    lowestNumOfZeroes = numOfZeroes;
                }                    
            }
            return CountCharInStringList('1', layerWithFewestZeroes) * CountCharInStringList('2', layerWithFewestZeroes);
        }

        /// <summary>
        /// Solve Day 8 Part 2.
        /// </summary>
        /// <returns>The result</returns>
        public object SolvePart2()
        {
            var width = 25;
            var height = 6;
            var imageData = ParseEncodedImage(_rawInput, width, height);
            List<string> imagePixels = ReconstituteImage(imageData);
            var image = string.Join(Environment.NewLine, imagePixels);
            Console.WriteLine("-- IMAGE --");
            Console.WriteLine("Black on white:");
            Console.WriteLine(image.Replace('1', ' ').Replace('0', '\u2588'));
            Console.WriteLine("White on black:");
            Console.WriteLine(image.Replace('0', ' ').Replace('1', '\u2588'));
            var answer = "AURCY";
            return answer;
        }

        private List<string> ReconstituteImage(IEnumerable<IEnumerable<string>> imageData)
        {
            var image = new List<string>();
            var numRows = imageData.ToList()[1].ToList().Count;
            var lenOfRows = imageData.ToList()[1].ToList()[1].Length;
            var processedRow = new List<char>();

            for (int row = 0; row < numRows; row++)
            {
                foreach (var layer in imageData)
                {
                    var currentRow = layer.ToList()[row];
                    for (int c = 0; c < lenOfRows; c++)
                    {
                        if (c >= processedRow.Count)
                        {
                            processedRow.Add(currentRow[c]);
                        }
                        else
                        {
                            if (processedRow[c] == '2')
                            {
                                processedRow[c] = currentRow[c];
                            }
                        }
                    }
                }
                image.Add(string.Join("", processedRow));
                processedRow = new List<char>();
            }
            return image;
        }

        /// <summary>
        /// Counts the total number of instances of a character within a list of strings.
        /// </summary>
        /// <param name="ch">The character to count</param>
        /// <param name="list">The list of strings to count from</param>
        /// <returns></returns>
        private static int CountCharInStringList(char ch, List<string> list)
        {
            var numOfChars = 0;
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
            var sourceAsList = input.ToList();
            for (int i = 0; i < sourceAsList.Count; i += size)
                yield return sourceAsList.GetRange(i, Math.Min(size, sourceAsList.Count - i));
        }
    }
}
