
using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;

namespace Chapter04
{
    public class Q04_5_IsBST : IQuestion
    {
        public bool IsBST( TreeNode node, int lower_limit=0, int upper_limit=0)
        {
            if(lower_limit !=0 && node.Data <lower_limit)
                return false;

            if (upper_limit != 0 && node.Data > upper_limit)
                return false;

            bool isLeftBst = true;
            bool isRightBst = true;

            if(node.Left != null)
            {
                isLeftBst = IsBST(node.Left, lower_limit, node.Data);
            }

            if (isLeftBst && node.Right != null)
            {
                isRightBst = IsBST(node.Right, node.Data, upper_limit);
            }

            return isLeftBst && isRightBst;
        }



        // Please see IsBst() implementation in TreeNode
        public void Run()
        {
            // Create balanced tree
            //int[] array = { 0, 1, 2, 3, 4, 5, 6 };  //should return true
            int[] array = { 0, 1, 2, 4, 5, 3, 6 };    //should return false
            var root = TreeNode.CreateMinimalBst(array);
            var result = IsBST(root);
            Console.WriteLine("Is balanced? "+ result);
        }
    }
}
