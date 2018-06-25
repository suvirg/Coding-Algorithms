using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace String_Problems
{
    public class PalindromeSubStrings : IQuestion
    {
        public List<string> CheckPalindromeSubStrings(string str)
        {
            List<string> result = new List<string>();
            char[] strArr = str.ToArray();
            for(int i=0;i<=strArr.Length-1;i++)
            {
                bool flip = false;
                int tempIndex = i;
                for (int j = i; j < strArr.Length - 1 && tempIndex >= 0;)
                {
                    string temp = str.Substring(tempIndex, j - tempIndex);
                    if(temp.Length > 1 && Palindrome.IsPalindrome( temp))
                    {
                        result.Add(temp);
                    }

                    if (flip)
                    {
                        j++;
                        flip = false;
                    }
                    else
                    {
                        tempIndex--;
                        flip = true;
                    }
                }
            }
            return result;
        }


        public int CheckPalindromeSubStrings2(string str)
        {
            int [,]T = new int[str.Length, str.Length];
            for(int i = 0; i<str.Length; i++)
            {
                T[i,i] = 1;
            }

            for (int l = 2; l <= str.Length; l++)
            {
                for (int i = 0; i<str.Length-l + 1; i++)
                {
                    int j = i + l - 1;

                    if (l == 2 && str[i] == str[j])
                    {
                        T[i,j] = 2;
                    }
                    else if (str[i] == str[j])
                    {
                        T[i,j] = T[i + 1,j - 1] + 2;
                    }
                    else
                    {
                        T[i,j] = Math.Max(T[i + 1,j], T[i,j - 1]);
                    }
                }
            }

            var res = T[0, str.Length - 1];
            return T[0, str.Length - 1];

        }


        public void Run()
        {
            string str = "abaabab";  //output => "aba" , "aa" , "baab" 
            //string str = "abbaeae";  //output => "bb" , "abba" ,"aea","eae"  //Todo - Work for this case....

            //var result = CheckPalindromeSubStrings(str);
            //foreach (var s in result)
            //{
            //    Console.WriteLine(s);
            //}

            var result2 = CheckPalindromeSubStrings2(str);
            
            Console.WriteLine("the longest palindrom substrsing length is  {0}", result2);
            
        }
    }
}
