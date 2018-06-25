using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Problem
{
    public class VerifyPostOrderSquenceOfBST : IQuestion
    {
        bool VerifyBSTArray(int[] sequence, int length)
        {
            if (sequence == null || length <= 0)
                return false;

            int root = sequence[length - 1];

            // nodes in left sub-tree are less than root node
            int i = 0;
            for (; i < length - 1; ++i)
            {
                if (sequence[i] > root)
                    break;
            }

            // nodes in right sub-tree are greater than root node
            int j = i;
            for (; j < length - 1; ++j)
            {
                if (sequence[j] < root)
                    return false;
            }

            // Is left sub-tree a binary search tree?
            bool left = true;
            if (i > 0)
                left = VerifyBSTArray(sequence, i);

            // Is right sub-tree a binary search tree?
            bool right = true;
            if (i < length - 1)
                right = VerifyBSTArray(sequence, length - i - 1);

            return (left && right);
        }
        public void Run()
        {
            int[] Arr = new int[] { 5, 7, 6, 9, 11, 10, 8 };//return True
            //int[] Arr = new int[] { 7, 4, 6, 5 };   //return false
            var result = VerifyBSTArray(Arr, Arr.Length);
        }
    }
}
