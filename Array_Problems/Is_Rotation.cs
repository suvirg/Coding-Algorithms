using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Problems
{
    public class Is_Rotation : IQuestion
    {
        public bool IsRotation(int [] arr1, int []arr2)
        {
            int key = arr1[0];
            int key_i = -1;
            if (arr1.Length != arr2.Length)
                return false;
            int i = 0;
            for(; i < arr2.Length - 1; i++)
            {
                if(arr2[i] == key)
                {
                    key_i = i;
                    break; 
                }
            }

            if (key_i == -1)
            {
                return false;
            }

            int j = 0;
            for (i =0; i < arr1.Length - 1; i++)
            {
                j = (key_i + i) % arr1.Length;     // Suvir => key of the Solution.....
                if (arr1[i] != arr2[j])
                    return false;
            }

            return true;
        }


        public void Run()
        {
            //NOTE: The following input values will be used for testing your solution.
            int[] list1 = { 1, 2, 3, 4, 5, 6, 7 };
            //int[] list2a = { 4, 5, 6, 7, 8, 1, 2, 3 };
            //is_rotation(list1, list2a) should return False.
            int[] list2b = { 4, 5, 6, 7, 1, 2, 3 };
            //is_rotation(list1, list2b) should return True.
            //int [] list2c = {4, 5, 6, 9, 1, 2, 3}
            //is_rotation(list1, list2c) should return False.
            //int [] list2d = [4, 6, 5, 7, 1, 2, 3]
            //is_rotation(list1, list2d) should return False.
            //int [] list2e = [4, 5, 6, 7, 0, 2, 3]
            //is_rotation(list1, list2e) should return False.
            //int [] list2f = [1, 2, 3, 4, 5, 6, 7]
            //is_rotation(list1, list2f) should return True.

            var result = IsRotation(list1, list2b);
            Console.WriteLine("IsRotation is {0}", result);


        }
    }
}
