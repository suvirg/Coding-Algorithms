using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Problems
{
    public class Common_ElementinTwoSorted : IQuestion
    {

        public List<int>  Common_elements(int []arr1, int []arr2)
        {
            List<int> result = new List<int>();
            int p1 = 0;
            int p2 = 0;
            while(p1<arr1.Length && p2<arr2.Length)
            {

                if(arr1[p1] == arr2[p2])
                {
                    result.Add(arr1[p1]);
                    p1++;
                    p2++;
                }
                else if (arr1[p1]>arr2[p2])
                {
                    p2++;

                }
                else
                {
                    p1++;
                }
            }

            return result;
        }

        public void Run()
        {
            // NOTE: The following input values will be used for testing your solution.
            int[] list_a1 = { 1, 3, 4, 6, 7, 9 };
            int[] list_a2 = { 1, 2, 4, 5, 9, 10};
            // Common_elements(list_a1, list_a2) should return [1, 4, 9] (a list).

            //   list_b1 = [1, 2, 9, 10, 11, 12]
            //   list_b2 = [0, 1, 2, 3, 4, 5, 8, 9, 10, 12, 14, 15]
            //   Common_elements(list_b1, list_b2) should return [1, 2, 9, 10, 12] (a list).

            //   list_c1 = [0, 1, 2, 3, 4, 5]
            //   list_c2 = [6, 7, 8, 9, 10, 11]
            //   Common_elements(list_b1, list_b2) should return [] (an empty list).

            //int[] list_c1 = { 0, 1, 2, 3, 4, 5 };
            //int[] list_c2 = { 6, 7, 8, 9, 10, 11};

            var results = Common_elements(list_a1, list_a2);

            Console.WriteLine("Common Elements are");
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
