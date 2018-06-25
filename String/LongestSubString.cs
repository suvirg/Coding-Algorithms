using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;

namespace String_Problems
{
    // Longest Substring Without repeating Chars....
    public class LongestSubString : IQuestion
    {
        public static int Find(string str)
        {
            int count = 0;
            int res = 0;
            int i = 0;
            int j = 0;
            List<char> charList = new List<char>();

            while (i < str.Length && j < str.Length)
            {
                if (!charList.Contains(str[j]))
                {
                    charList.Add(str[j++]);
                    count++;
                }
                else
                {
                    charList.Remove(str[i++]);
                    count--;
                }
                res = Math.Max(res, count);
            }

            return res;
        }

        int lengthOfLongestSubstring(string s)
        {
            int[] map = new int[128];
            int counter = 0, begin = 0, end = 0, d = 0;
            while (end < s.Length)
            {
                if (map[s[end++]]++ > 0) counter++;
                while (counter > 0) if (map[s[begin++]]-- > 1) counter--;
                d = Math.Max(d, end - begin); //while valid, update d
            }
            return d;
        }
        
        public void Run()
        {
            string str = "abbccd";
            int result1 = Find(str);
            int result2 = lengthOfLongestSubstring(str);
            
            Console.WriteLine("Longestsubstring result1 = {0} result2 = {1}", result1, result2);
            Console.ReadLine();
        }
    }
}
