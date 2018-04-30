using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Problems
{
    //https://www.careercup.com/question?id=5725965217955840
    public  class K_EquallyBucket : IQuestion
    {
        public static List<List<int>> ArraySplit(int[] arr, int k)
        {
            List<List<int>> res = new List<List<int>>();
            int i = 0;
            for (i = arr.Length - 1; i >= (arr.Length - k); i--)
            {
                List<int> temp = new List<int>();
                temp.Add(arr[i]);
                res.Add(temp);
            }
            //int c = 0;
            while (i >= 0)
            {
                int c = getListIndexWithMinSum(res);
                res[c].Add(arr[i]);
                i--;
            }
            return res;
        }

        private static int getListIndexWithMinSum(List<List<int>> arr)
        {
            int minIndex = 0;
            int minSum = int.MaxValue;
            int i = 0;
            foreach (var l in arr)
            {
                int currSum = sum(l);
                if (minSum > currSum)
                {
                    minSum = currSum;
                    minIndex = i;
                }
                i++;
            }
            return minIndex;
        }

        private static int sum(List<int> arr)
        {
            int sum = 0;
            foreach (int n in arr)
            {
                sum += n;
            }
            return sum;
        }

        public void Run()
        {
            int[] arr = { 1, 3, 6, 9, 10 };
            List<List<int>> res = ArraySplit(arr, 3);
            Console.WriteLine("K Equally Weighted Buckets are");
            foreach (List<int> list in res)
            {
                foreach(var item in list)
                {
                    Console.WriteLine(list);
                }
            }

            Console.WriteLine("K Equally Weighted Buckets are");
        }
    }
}
