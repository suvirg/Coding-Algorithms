using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems
{
    class ShortestPalindrom : IQuestion
    {
        public static string Find(string str)
        {
            string result = string.Empty;

            if (str.Length == 1)
                return str;
            else
            {
                if (Palindrome.IsPalindrome(str))
                    return str;
            }


            StringBuilder sb = new StringBuilder();

            for (int i = str.Length; i > 0; i--)
            {
                string s = ReverseString.Reverse(str.Substring(i - 1));

                sb.Append(s);
                sb.Append(str);

                if (Palindrome.IsPalindrome(sb.ToString()))
                {
                    if (sb.Length < result.Length || result == string.Empty)
                        result = sb.ToString();
                }
                sb.Clear();

            }
            return result;
        }


        public void Run()
        {
            //Shortes palindrome strings by adding characted at front
            //Example => For example, given "aacecaaa", return "aaacecaaa"; given "abcd", return "dcbabcd"
            string str = "abbacd";

            var result = Find(str);
            Console.WriteLine("the shortest Palindrom {0}", result);
            Console.ReadLine();
            
        }
    }
}
