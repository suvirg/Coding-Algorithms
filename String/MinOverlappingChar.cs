using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems
{
    // https://www.careercup.com/question?id=5720235523964928
    // Input: [a, b, c, b, a, e, b, a, d, f, g, d, f, i, f, k, l, m, n, m, l]
    // Output: [8, 7, 6]
    // Explanation: max length from 1st 'a' to last 'a' is 8.
    //TODO- Suvir Problem was not fully Solved Revisit Later.....
    public class MinOverlappingChar : IQuestion
    {
        private List<int>  FindOverlappingWindow(char [] str)
        {
            List<int> result = new List<int>();
            Dictionary<char, List<int>> dictArr = new Dictionary<char, List<int>>();
            int index = 0;
            foreach(var c in str)
            {
                if(!dictArr.ContainsKey(c))
                {
                    dictArr.Add(c, new List<int>() { index, 0 });
                }
                else
                {
                    var listData = dictArr[c];
                    listData[1] = index;
                    dictArr[c] = listData;

                }
                index++;
            }

            foreach(var item in dictArr)
            {
                var value = item.Value;
                if(value.ElementAt(1) > value.ElementAt(0))
                {
                    result.Add(value.ElementAt(1) - value.ElementAt(0));
                }
                
            }

            return result;
        }
        public void Run()
        {
            char[] charArr = { 'a', 'b', 'c', 'b', 'a', 'e', 'b', 'a', 'd', 'f', 'g', 'd', 'f', 'i', 'f', 'k', 'l', 'm', 'n', 'm', 'l' };
            var result = FindOverlappingWindow(charArr);


        }
    }
}
