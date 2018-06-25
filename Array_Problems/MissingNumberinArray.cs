using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Problems
{
    public class MissingNumberinArray : IQuestion
    {
        public static IList<int> FindMissingNumberinArray(int[] nums)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var val = Math.Abs(nums[i]) - 1;

                if (nums[val] > 0)
                    nums[val] = -nums[val];

            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    result.Add(i + 1);
                }
            }

            return result;
        }



        public void Run()
        {
            int[] intArr = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 };

            var result = FindMissingNumberinArray(intArr);

            foreach (var res in result)
            {
                Console.WriteLine("LargestNumber  {0}", res);
            }
            Console.ReadLine();
        }
    }
}
