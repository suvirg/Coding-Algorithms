using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAlgorithms.Library
{
    public class Palindrome
    {
        public static bool IsPalindrome(string str)
        {
            //char[] charString = str.ToCharArray();
            //int length = str.Length - 1;
            //int j = length;
            //for (int i = 0; i < length; j--, i++)
            //{
            //    char temp = charString[j];
            //    charString[j] = charString[i];
            //    charString[i] = charString[j];
            //}

            //bool result = str.Equals(new String(charString), StringComparison.Ordinal);
            //return result;

            int left = 0;
            int right = str.Length - 1;
            while (left <= right)
            {
                if (str[left++] != str[right--]) return false;
            }
            return true;


        }

    }
}
