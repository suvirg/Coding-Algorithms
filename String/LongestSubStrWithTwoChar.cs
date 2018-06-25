using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems
{
    public class LongestSubStrWithTwoChar : IQuestion
    {
        //string str = "abcbbbbcccbdddadacb"; /// Ans(10) => bcbbbbcccb

        public static int Find(string str)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            int start = 0;
            int max = 0;

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (!dic.ContainsKey(str[i]))
                {
                    dic.Add(str[i], 1);
                }
                else
                {
                    int count = 0;
                    dic.TryGetValue(str[i], out count);
                    dic[str[i]] = count + 1;
                }

                if (dic.Count > 2)
                {
                    max = Math.Max(max, i - start);

                    while (dic.Count > 2)
                    {
                        int count = 0;
                        dic.TryGetValue(str[start], out count);
                        if (count > 1)
                            dic[str[start]] = count - 1;
                        else
                            dic.Remove(str[start]);
                        start++;
                    }
                }

            }

            max = Math.Max(max, str.Length - start);
            return max;
        }
        
        public void Run()
        {
            string str = "abcbbbbcccbdddadacb"; /// Ans(10) => bcbbbbcccb
            int result = Find(str);
            Console.WriteLine("Longestsubstring {0}", result);
            Console.ReadLine();
        }
    }
}
