using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAlgorithms.Library
{
    public class CheckIsomorphic
    {
        public static bool CheckIsomorphicString(string s, string t)
        {
            int[] m1 = new int[256];
            int[] m2 = new int[256];

            for (int i = 0; i < m1.Length; i++)
            {
                m1[i] = m2[i] = 0;

            }
            int n = s.Length;

            for (int i = 0; i < n; ++i)
            {
                if (m1[s[i]] != m2[t[i]])
                    return false;
                m1[s[i]] = i + 1;
                m2[t[i]] = i + 1;
            }
            return true;
        }
    }
}
