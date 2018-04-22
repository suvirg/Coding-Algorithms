using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems
{
    public class PermuteLetters : IQuestion
    {
        public static void printPermutate(string[] words, int index, string print)
        {
            string word = words[index];

            for (int x = 0; x < word.Length; x++)
            {
                if ((print + word[x].ToString()).Length == words.Count())
                {
                    Console.WriteLine(print + word[x].ToString());

                }
                else if (index + 1 < words.Count())
                {
                    printPermutate(words, index + 1, print + word[x].ToString());
                }
            }
            return;
        }


        public void Run()
        {
            string[] words = new string[] { "red", "fox", "super", "test" };

            printPermutate(words, 0, "");
            throw new NotImplementedException();
        }
    }
}
