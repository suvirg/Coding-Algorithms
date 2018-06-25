using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tree_Problem
{
    // https://www.geeksforgeeks.org/print-binary-tree-vertical-order-set-2/

    public class PrintInVerticalOrder : IQuestion
    {
        SortedDictionary<int, List<int>> veticalOrder = new SortedDictionary<int, List<int>>();

        public TreeNode PrintVerticalOrder(TreeNode root, int level)
        {
            if (root == null)
                return null;

            if(veticalOrder.ContainsKey(level))
            {
                var value = veticalOrder[level];
                value.Add(root.Data);
                veticalOrder[level] = value;
            }
            else
            {
                veticalOrder.Add(level, new List<int>() { root.Data });

            }
            
            TreeNode node = PrintVerticalOrder(root.Left, --level);

            if(node == null)
            {
                level++;
            }

            return PrintVerticalOrder(root.Right, ++level);

        }

        public void Run()
        {
            TreeNode root = new TreeNode(1);
            root.Left  = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(5);
            root.Right.Left = new TreeNode(6);
            root.Right.Right = new TreeNode(7);
            root.Right.Left.Right = new TreeNode(8);
            root.Right.Right.Right = new TreeNode(9);
            Console.WriteLine("Vertical Order traversal is");
            PrintVerticalOrder(root, 0);

            StringBuilder sb = new StringBuilder();

            foreach (var key in veticalOrder.Keys)
            {
                foreach (var val in veticalOrder[key])
                {
                    sb.Append(val.ToString());
                    sb.Append(',');
                    
                }
                Console.WriteLine(sb);
                sb.Clear();
            }
        }
    }
}
