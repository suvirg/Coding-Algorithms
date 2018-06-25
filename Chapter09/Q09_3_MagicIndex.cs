using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09
{
    public class Q09_3 : IQuestion
    {
        public int MagicFast(int []arr, int start, int end)
        {
            if (end < start || start < 0 || end > arr.Length)
                return -1;

            int mid = (start + end) / 2;

            if (arr[mid] == mid)
                return mid;
            else if (arr[mid] < mid)
                return MagicFast(arr, mid + 1, end);
            else if (arr[mid] > mid)
                return MagicFast(arr, start, mid - 1);
            return -1;
        }

        public void Run()
        {
            int[] arr = new int[] {-40, -20, -1, 1, 2, 3, 5, 7, 9, 12, 13 };
            var res = MagicFast(arr, 0, arr.Length - 1);
            Console.WriteLine("magic index is {0}", res);
        }
    }
}
