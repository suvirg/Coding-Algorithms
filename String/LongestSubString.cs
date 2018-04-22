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

        public void Run()
        {
            string str = "abbccd";
            int result = Find(str);
            Console.WriteLine("Longestsubstring {0}", result);
            Console.ReadLine();
        }
    }
}
