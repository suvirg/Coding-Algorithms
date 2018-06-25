using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems
{
    public class MinWindowSubString : IQuestion
    {
        public static string Find(string s, string t)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            Dictionary<char, int> currentMap = new Dictionary<char, int>();
            int charCount = t.Length;
            int count = 0;
            int startIndex = 0;

            string finalString = string.Empty;

            foreach (var c in t)
            {
                if (map.ContainsKey(c))
                {
                    map[c] = map[c] + 1;
                }
                else
                {
                    map.Add(c, 1);
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i]))
                {
                    if (!currentMap.ContainsKey(s[i]))
                    {
                        currentMap.Add(s[i], 1);
                    }
                    else
                    {
                        currentMap[s[i]] = currentMap[s[i]] + 1;
                    }
                    if (currentMap.ContainsKey(s[i]))
                    {
                        if (currentMap[s[i]] <= map[s[i]])
                        {

                            if (count == 0)
                                startIndex = i;
                            count++;
                        }
                    }

                }

                if (count == charCount)
                {
                    char c = s[startIndex];
                    while (!currentMap.ContainsKey(c) || currentMap[c] > map[c])
                    {
                        if (currentMap.ContainsKey(c) && currentMap[c] > map[c])
                            currentMap[c] = currentMap[c] - 1;
                        startIndex++;
                        c = s[startIndex];
                    }


                    if (finalString.Length > s.Substring(startIndex, i - startIndex + 1).Length || finalString == string.Empty)
                        finalString = s.Substring(startIndex, i - startIndex + 1);

                    currentMap.Clear();
                    i = startIndex + 1;

                    count = 0;
                }
            }

            return finalString;

        }

        //public static string Find_ver2(string s, string t)
        //{
        //    Dictionary<char, int> map = new Dictionary<char, int>();
        //    foreach (var c in t.ToCharArray())
        //    {
        //        map.merge(c, 1, Integer::sum);
        //    }

        //    int begin = 0;
        //    int end = 0;
        //    int count = t.length();
        //    int head = 0, tail = 0;
        //    int diff = Integer.MAX_VALUE;
        //    while (end < s.length())
        //    {
        //        char e = s.charAt(end);

        //        if (map.merge(e, -1, Integer::sum) >= 0)
        //        { // map.merge() returns the final result
        //            count--;
        //        }
        //        while (count == 0)
        //        {
        //            char b = s.charAt(begin);

        //            if (diff > end - begin)
        //            {
        //                head = begin;
        //                // +1 because of exclusive s.substring() call below
        //                tail = end + 1;
        //                diff = tail - head;
        //            }
        //            if (map.merge(b, +1, Integer::sum) > 0)
        //            { // map.merge() returns the final result
        //                count++;
        //            }
        //            begin++;
        //        }
        //        end++;
        //    }

        //    return s.substring(head, tail);
        //}

        public void Run()
        {
            //For example,
            string s = "ADOBECODEBANC";
            string t = "ABC";
            //Minimum window is "BANC".
            //string s = "bba";
            //string t = "ab";
            var result = Find(s, t);
            Console.WriteLine("Minimum window is {0}", result);
            Console.ReadLine();
        }
    }
}
