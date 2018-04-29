using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAlgorithms.Library
{
    public class EncodeIntToString
    {
        public static string Encode(string intPresentation)
        {
            const int AsciiOffset = 96; // for example 'a' ASCII code is 1 + 96 = 97

            return ((char)(int.Parse(intPresentation) + AsciiOffset)).ToString();
        }
    }
}
