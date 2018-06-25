using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Problems
{
    public class KthLargestElement : IQuestion
    {
        public int FindElement(int [] nums, int k)
        {
            int left = 0, right = nums.Length - 1;
            while (true)
            {
                int pos = Partition(nums, left, right);
                if (pos == k - 1)
                    return nums[pos];
                if (pos > k - 1)
                    right = pos - 1;
                else
                    left = pos + 1;
            }
        }

        private int Partition(int [] nums, int left, int right)
        {
            int pivot = nums[left];
            int l = left + 1, r = right;
            while (l <= r)
            {
                if (nums[l] < pivot && nums[r] > pivot)
                    // swap(nums[l++], nums[r--]);
                    Swap(nums, l++, r--);
                if (nums[l] >= pivot)
                    l++;
                if (nums[r] <= pivot)
                    r--;
            }
            // swap(nums[left], nums[r]);
            Swap(nums, left, r);
            return r;
        }

        private void Swap(int [] arr, int indexSource, int indexTarget)
        {
            int temp = arr[indexSource];
            arr[indexSource] = arr[indexTarget];
            arr[indexTarget] = temp;
        }

        public void Run()
        {
            // int[] arr = { 3, 2, 1, 5, 6, 4 };
            // int k = 2;
            int[] arr = { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            int k = 4;
            var res = FindElement(arr, k);
        }
    }
}
