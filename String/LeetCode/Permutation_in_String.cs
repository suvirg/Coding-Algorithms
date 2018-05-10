using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems
{
    //567. Permutation in String
    //https://leetcode.com/problems/permutation-in-string/description/

    public class Permutation_in_String : IQuestion
    {

        private bool FindPermutations(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                return false;
            int[] arrS1Map = new int[26];
            
            char[] arrS1 = s1.ToArray();
            char[] arrS2 = s2.ToArray();

            for (int i = 0; i < arrS1.Length; i++)
            {
                arrS1Map[s1[i]-'a']++;
            }
            for(int i=0;i< s2.Length - s1.Length; i++)
            {
                int[] arrS2Map = new int[26];
                for (int j = 0; j < arrS1.Length; j++)
                {
                    arrS2Map[s2[i+j] - 'a']++;
                }
                if (isMatch(arrS1Map, arrS2Map))
                    return true;
            }

            return false;
        }
        private bool isMatch(int [] arrS1Map, int[] arrS2Map)
        {
            for (int i = 0; i < 26; i++)
            {
                if (arrS1Map[i] != arrS2Map[i])
                    return false;
            }
            return true;
        }

        public void Run()
        {
            string s1 = "abc";
            string s2 = "eidbacooo";
            var result = FindPermutations(s1, s2);
            Console.WriteLine("String in permutaion is {0}", result);

         }
    }
}
