using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems
{
    public class PalindromeSubStrings : IQuestion
    {
        //public List<string> CheckPalindromeSubStrings(string str)
        public string CheckPalindromeSubStrings(string str)
        {
            //List<string> result = new List<string>();
            string result = "";
            char[] strArr = str.ToArray();
            for(int i=0;i<=strArr.Length-1;i++)
            {
                bool flip = false;
                int tempIndex = i;
                for (int j = i; j < strArr.Length - 1 && tempIndex >= 0;)
                {
                    string temp = str.Substring(tempIndex, j - tempIndex);
                    if (result.Length < temp.Length)
                    {
                        if (temp.Length > 2 && Palindrome.IsPalindrome(temp))
                        {
                            result = temp;
                        }
                    }

                    if (flip)
                    {
                        j = j + 1;
                        flip = false;
                    }
                    else
                    {
                        tempIndex = tempIndex - 1;
                        flip = true;
                    }
                }
            }
            return result;
        }

        public void Run()
        {
            //string str = "abaab";  //output => "aba" , "aa" , "baab" 
            string str = "abababaaba";  //output => "bb" , "abba" ,"aea","eae"  //Todo - Work for this case....
            var result = CheckPalindromeSubStrings(str);
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }
    }
}
