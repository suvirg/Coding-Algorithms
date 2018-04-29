using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Problem
{
    public class PrintLevelOrder : IQuestion
    {
        Queue<TreeNode> items = new Queue<TreeNode>();

        public void PrintLevel(TreeNode root)
        {
            // Base Case
            if (root == null)
                return;
            items.Enqueue(root);
            bool leftReached = false;
            bool rightReached = false;

            while (true)
            {

                // nodeCount (queue size) indicates number of nodes
                // at current level.
                int nodeCount = items.Count;
                if (nodeCount == 0)
                    break;
                if (leftReached && rightReached)
                    break;

                // Dequeue all nodes of current level and Enqueue all
                // nodes of next level
                while (nodeCount > 0)
                {
                    TreeNode node = items.Dequeue();
                    Console.WriteLine(node.Data);

                    if (node.Left != null)
                        items.Enqueue(node.Left);
                    else
                        leftReached = true;
                    if (node.Right != null)
                        items.Enqueue(node.Right);
                    else
                        rightReached = true;

                    nodeCount--;
                }
            }
        }

        public void Run()
        {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(5);
            root.Right.Right = new TreeNode(6);

            PrintLevel(root);

            foreach(var item in items)
            {
                Console.WriteLine(item);
            }



        }
    }
}
