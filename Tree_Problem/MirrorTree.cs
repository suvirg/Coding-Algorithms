using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Problem
{
    public class MirrorTree : IQuestion
    {
        public TreeNode GenerateMirrorTree(TreeNode root)
        {
            if(root ==null)
            {
                return null;
            }

            GenerateMirrorTree(root.Left);
            GenerateMirrorTree(root.Right);

            TreeNode temp = root.Right;
            root.Right = root.Left;
            root.Left = temp;
            return root;
        }
                

        public void Run()
        {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(5);
            root.Right.Right = new TreeNode(6);
            BTreePrinter.Inorder(root);
            var result = GenerateMirrorTree(root);
            BTreePrinter.Inorder(result);
        }
    }
}
