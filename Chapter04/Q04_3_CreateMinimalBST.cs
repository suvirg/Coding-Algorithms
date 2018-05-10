
using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;

namespace Chapter04
{
    public class Q04_3_CreateMinimalBST : IQuestion
    {
        // Please see first part of Run in Q04_2 and CreateMinimalBst implementation
        public void Run()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var root = TreeNode.CreateMinimalBst(array);
            Console.WriteLine("Root? " + root.Data);
        }
    }
}
