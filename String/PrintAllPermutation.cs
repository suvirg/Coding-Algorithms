using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace String_Problem
{
    public class PrintAllPermutation : IQuestion
    {
        static public List<String> printAllPermutationString(string s)
        {
            List<String> permutations = new List<String>();
            if (s == null)
            {
                return null;

            }
            else if (s.Length == 0)
            { // base case
                permutations.Add("");    //Suvir-> key is Adding nothing and retunrnew list...
                return permutations;

            }

            char first = s.ElementAt(0); // get the first character
            String remainder = s.Substring(1); // remove the first character
            List<String> words = printAllPermutationString(remainder);
            foreach (String word in words)
            {
                for (int j = 0; j <= word.Length; j++)
                {
                    permutations.Add(insertCharAt(word, first, j));
                }
            }
            return permutations;
        }

        public static String insertCharAt(String word, char c, int i)
        {
            String start = word.Substring(0, i);
            String end = word.Substring(i);
            return start + c + end;

        }

        //static public void printAllPermutationString_ver2(string prefix, string suffix, List<string> result)
        //{
        //    if(suffix.Length ==0)
        //    {
        //        result.Add(prefix);
        //    }
        //    else
        //    {
        //        for(int i=0; i< suffix.Length; i++)
        //        {
        //            printAllPermutationString_ver2(prefix + suffix[i], suffix.Substring(0, i) + suffix.Substring(i + 1, suffix.Length-1), result);

        //        }
        //    }
        //}

        public void Run()
        {
            // var res = GetStringFrom("12345678");
            int count = 0;
            var finalstring = printAllPermutationString("12345");
            foreach (var s in finalstring)
            {
                Console.WriteLine(s);

                count++;
            }

            //revisit Later not a working solution...
            //List<string> finalstring = new List<string>();
            //printAllPermutationString_ver2("","abc", finalstring);
            //Console.WriteLine("Total Permutations : = {0}", finalstring.Count);
            //foreach (var s in finalstring)
            //{
            //    Console.WriteLine(s);

            //}
            Console.ReadLine();

        }
    }
}
