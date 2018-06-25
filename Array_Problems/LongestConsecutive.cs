using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Problems
{
    public class LongestConsecutive : IQuestion
    {
        int FindLongestConsecutive(int [] nums)
        {
            int max = 0;
            List<int> list = new List<int>();
            foreach (var num in nums)
            {
                list.Add(num);
            }
            foreach (var num in nums)
            {
                int left = num - 1;
                int right = num + 1;
                int count = 1;
                while (list.Contains(left))
                {
                    count++;
                    list.Remove(left);
                    left--;
                }

                while (list.Contains(right))
                {
                    count++;
                    list.Remove(right);
                    right++;
                }
                max = Math.Max(count, max);
            }
            return max;

        }

        public void Run()
        {
            int[] Arr = new int[] { 100, 4, 200, 1, 3, 2 };
            int result = FindLongestConsecutive(Arr);
            Console.WriteLine("MinimalLengthSubArray {0}", result);
            Console.ReadLine();
        }
    }
}
