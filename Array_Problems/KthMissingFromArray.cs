using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Problems
{
    // https://www.careercup.com/question?id=5667690264920064
    //https://www.geeksforgeeks.org/k-th-missing-element-in-sorted-array/
    public class KthMissingFromArray : IQuestion
    {
        public int FindMissing(int[] list, int num)
        {
            int k = 0, val = 0;
            if (list.Length < 2) return -1;
            val = list[0];
            for (int i = 0; i < list.Length - 1; ++i)
            {
                val = list[i];
                while ((list[i + 1] - val) > 1)
                {
                    val++;
                    if (k == num) return val;
                    k++;
                }
                    
            }
            return -1;

        }

        public void Run()
        {
            int [] a = new int[] { 2, 3, 5, 9, 10, 11, 12 };

            // k-th missing element 
            // to be found in the array
            int k = 0;
            int n = a.Length;

            // calling function to
            // find missing element
            int missing = FindMissing(a, k);
            Console.WriteLine("Missing Number if {0}", missing);

        }
    }
}
