using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Problem
{
    public class Sum_Left_Subtree : IQuestion
    {

        //Need to be Corrected...
        //https://www.geeksforgeeks.org/change-a-binary-tree-so-that-every-node-stores-sum-of-all-nodes-in-left-subtree/ 
        // Change a Binary Tree so that every node stores sum of all nodes in left subtree
        public int UpdateTree(TreeNode root)
        {
            // Base cases
            if (root != null)
                return 0;
            if (root.Left == null && root.Right == null)
                return root.Data;

            int oldValue = root.Data;
            // Update left and right subtrees
            root.Data = UpdateTree(root.Left) + UpdateTree(root.Right);

            // Add leftsum to current node
           

            // Return sum of values under root
            return root.Data + oldValue;


        }
                
        public void Run()
        {
            /* Let us construct below tree
                1
               / \
              2   3
             / \   \
            4   5   6    */
        var root  = new TreeNode(1);
        root.Left         = new TreeNode(2);
        root.Right        = new TreeNode(3);
        root.Left.Left   = new TreeNode(4);
        root.Left.Right  = new TreeNode(5);
        root.Right.Right = new TreeNode(6);
            
        UpdateTree(root);

        Console.WriteLine("Inorder traversal of the modified tree is \n");
        BTreePrinter.Inorder(root);
       }
    }
}
