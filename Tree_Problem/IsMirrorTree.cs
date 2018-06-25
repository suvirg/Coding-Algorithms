using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Problem
{
    public class IsMirrorTree : IQuestion
    {
        //https://www.careercup.com/question?id=5169267562512384
        public bool IsMirroredTree(TreeNode t)
        {
            if (t != null) return IsMirrored(t.Left, t.Right);
            return false;
        }
        public bool IsMirrored(TreeNode a, TreeNode b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            if (a.Data == b.Data)
            {
                return IsMirrored(a.Left, b.Right) && IsMirrored(a.Right, b.Left);
            }

            return false;
        }

        public void Run()
        {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(2);
            root.Left.Left = new TreeNode(3);
            root.Left.Right = new TreeNode(4);
            root.Right.Left = new TreeNode(4);
            root.Right.Right = new TreeNode(3);
            var result = IsMirroredTree(root);
            Console.WriteLine("Is Mirrored {0}", result);
        }
    }
}
