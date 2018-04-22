using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAlgorithms.Library
{
    public class RemoveDuplicate
    {
        public static string RemoveDuplicateFromString(string str)
        {
            char[] strArr = str.ToCharArray();
            HashSet<char> charStr = new HashSet<char>();

            foreach (var s in str)
            {
                if (!charStr.Contains(s))
                    charStr.Add(s);
            }

            return new string(charStr.ToArray());
        }
    }
}
