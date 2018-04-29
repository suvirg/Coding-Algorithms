using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;

namespace Tree_Problem
{
    public class DiameterOfTree : IQuestion
    {

        public int CalculateDiameter(TreeNode root)
        {
            if (root == null)
                return 0;
           
            int lheight = height(root.Left);
            int rheight = height(root.Right);

            int ldiameter = CalculateDiameter(root.Left);
            int rdiameter = CalculateDiameter(root.Right);

            /* Return max of following three
              1) Diameter of left subtree
              2) Diameter of right subtree
              3) Height of left subtree + height of right subtree + 1 */
            return Math.Max(lheight + rheight + 1, Math.Max(ldiameter, rdiameter));

       }

        public int CalculateDiameterOptimized(TreeNode root, int height)
        {
            int lh = 0; 
            int rh = 0;

            if (root == null)
            {
                height = 0;
                return 0; /* diameter is also 0 */
            }

            /* ldiameter  --> diameter of left subtree
               rdiameter  --> Diameter of right subtree */
            /* Get the heights of left and right subtrees in lh and rh
             And store the returned values in ldiameter and ldiameter */
            lh++; rh++;
            int ldiameter = CalculateDiameterOptimized(root.Left, lh);
            int rdiameter = CalculateDiameterOptimized(root.Right, rh);

            /* Height of current node is max of heights of left and
             right subtrees plus 1*/
            height = Math.Max(lh, rh) + 1;

            return Math.Max(lh + rh + 1, Math.Max(ldiameter, rdiameter));


        }




        private int height(TreeNode root)
        {
            if (root == null)
                return 0;

            int left_height = height(root.Left);

            int right_height = height(root.Right);

            // update the answer, because diameter of a
            // tree is nothing but maximum value of
            // (left_height + right_height + 1) for each node

            return 1 + Math.Max(left_height, right_height);
        }

        public void Run()
        {

            //TODO - Suvir - Not Sure which one is correct....
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(5);
            //Console.WriteLine("Diameter is {0}\n", CalculateDiameter(root));
            Console.WriteLine("Diameter is {0}\n", CalculateDiameterOptimized(root, 0));

            
        }
    }
}
