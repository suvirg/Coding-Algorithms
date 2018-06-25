using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Problem
{
    public class MaxPathSum : IQuestion
    {
        public int getMaxPathSum(TreeNode root)
        {
            int suml = 0;
            int sumr = 0;
            if (root.Left == null && root.Right == null)
                return root.Data;
            if (root.Left != null)
            {
                suml = suml + root.Data + getMaxPathSum(root.Left);
            }
            if (root.Right != null)
            {
                sumr = sumr + root.Data + getMaxPathSum(root.Right);
            }

            return Math.Max(suml, sumr);
        }
        public void Run()
        {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(5);
            root.Right.Right = new TreeNode(6);
            var result = getMaxPathSum(root);

            Console.WriteLine("the max path sum is {0}", result);
        }
    }
}
