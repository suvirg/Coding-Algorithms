using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems 
{
    public class ScrambleString : IQuestion
    {

        public bool IsScramble(string s1, string s2)
        {
            if (s1 == s2)
                return true;

            int len = s1.Length;
            int[] count = new int[26];
            for (int i = 0; i < len; i++)
            {
                count[s1[i] - 'a']++;
                count[s2[i] - 'a']--;
            }

            for (int i = 0; i < 26; i++)
            {
                if (count[i] != 0)
                    return false;
            }

            for (int i = 1; i <= len - 1; i++)
            {
                if (IsScramble(s1.Substring(0, i), s2.Substring(0, i)) && IsScramble(s1.Substring(i), s2.Substring(i)))
                    return true;
                if (IsScramble(s1.Substring(0, i), s2.Substring(len - i)) && IsScramble(s1.Substring(i), s2.Substring(0, len - i)))
                    return true;
            }
            return false;
        }


        public void Run()
        {
            string s1 = "great";
            string s2 = "rgeat";
            var result = IsScramble(s1, s2);
            Console.WriteLine("Two String {0} and {1} are scambled {3}", s1, s2, result);
        }
    }
}
