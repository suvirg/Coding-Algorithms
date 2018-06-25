
using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Problems
{
    //asked in Google.
    //https://www.careercup.com/page?pid=arrays-interview-questions


    public class FindClosest : IQuestion
    {

        public int Find(int []input, int target)
        {
            if (input.Length == 0)
                return -1;

            if (target < input[0])
                return input[0];

            if (target > input[input.Length - 1])
                return input[input.Length - 1];

            int i = 0;
            int j = input.Length;

            while (i < j)
            {
                int mid = (i + j) / 2;

                if (input[mid] == target)
                    return target;

                if (target < input[mid])
                {
                    if (target > input[mid - 1])
                    {
                        return getClosest(input[mid - 1], input[mid], target);
                    }
                    j = mid;
                }
                else if (target > input[mid])
                {
                    if (target < input[mid + 1])
                    {
                        return getClosest(input[mid], input[mid + 1], target);
                    }
                    i = mid + 1;
                }
            }
            return 0;
        }

        public int getClosest(int value1, int value2, int target)
        {
            if (target - value1 >= value2 - target)
            {
                return value2;
            }
            else
            {
                return value1;
            }
        }

        public void Run()
        {
            // Given an array of sorted integers and find the closest value to the 
            // given number.Array may contain duplicate values and negative numbers.
            // Example :  Array : 2,5,6,7,8,8,9
            // Target number : 5 
            // Output : 5
            // Target number : 11
            // Output : 9
            // Target Number : 4 
            // Output : 5

            int[] input = new int[] { 2, 5, 6, 7, 8, 8, 9 };
            int element = 4;
            int result = Find(input, element);
            Console.WriteLine("the Closest element to {0} is {1}", element, result);
        }
    }
}
