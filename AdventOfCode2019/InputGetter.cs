using System.IO;

namespace AdventOfCode2019
{
    class InputGetter
    {
        public readonly string rootSourcePath = @"..\..\";

        public InputGetter() { }

        public string GetRawString(string fileName)
        {
            string rawString;
            using (StreamReader reader = new StreamReader(rootSourcePath + fileName))
            {
                rawString = reader.ReadToEnd();
            }
            return rawString;
        }
    }
}
