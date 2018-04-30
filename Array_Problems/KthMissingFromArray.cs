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
        public int FindMissing(int[] Arr, int k)
        {
            int difference = 0;
            int ans = 0, count = k;
            bool flag = false;

            // interating over the array
            for (int i = 0; i < Arr.Length - 1; i++)
            {
                difference = 0;

                // check if i-th and 
                // (i + 1)-th element 
                // are not consecutive
                if ((Arr[i] + 1) != Arr[i + 1])
                {
                    // save their difference
                    difference += (Arr[i + 1] - Arr[i]) - 1;
                    // check for difference
                    // and given k
                    if (difference >= count)
                    {
                        ans = Arr[i] + count;
                        flag = true;
                        break;
                    }
                    else
                        count -= difference;
                }
            }

            // if found
            if (flag)
                return ans;
            else
                return -1;
        }

        public void Run()
        {
            int [] a = new int[] { 2, 3, 5, 9, 10, 11, 12 };

            // k-th missing element 
            // to be found in the array
            int k = 4;
            int n = a.Length;

            // calling function to
            // find missing element
            int missing = FindMissing(a, k);
            Console.WriteLine("Missing Number if {0}", missing);

        }
    }
}
