using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Problem
{
    public class DeleteTreeNode : IQuestion
    {
        TreeNode DeleteNode(TreeNode root, int key)
        {
            /* Base Case: If the tree is empty */
            if (root == null) return root;

            /* Otherwise, recur down the tree */
            if (key < root.Data)
                root.Left = DeleteNode(root.Left, key);
            else if (key > root.Data)
                root.Right = DeleteNode(root.Right, key);

            // if key is same as root's key, then This is the node
            // to be deleted
            else
            {
                // node with only one child or no child
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                // node with two children: Get the inorder successor (smallest
                // in the right subtree)
                root.Data = MinValue(root.Right);

                // Delete the inorder successor
                root.Right = DeleteNode(root.Right, root.Data);
            }

            return root;
        }



        private int MinValue(TreeNode root)
        {
            int minv = root.Data;
            while (root.Left != null)
            {
                minv = root.Left.Data;
                root = root.Left;
            }
            return minv;
        }

        public void Run()
        {
            /*
                      50                            50
                   /     \         delete(20)      /   \
                  30      70       --------->    30     70 
                 /  \    /  \                     \    /  \ 
               20   40  60   80                   40  60   80
           */

            TreeNode root = new TreeNode(50);
            root.Left = new TreeNode(30);
            root.Right = new TreeNode(70);
            root.Left.Left = new TreeNode(20);
            root.Left.Right = new TreeNode(40);
            root.Right.Left = new TreeNode(60);
            root.Right.Right = new TreeNode(80);
            DeleteNode(root, 20);
            BTreePrinter.Inorder(root);
        }
    }
}
