using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Problem
{
     class QueueNode
	 {
	        public TreeNode node;
            public int level;
	        
	        public QueueNode(TreeNode node, int level)
	        {
	            this.node = node;
	            this.level = level;
	        }
	  }

    public class PrintLeftView : IQuestion
    {
        public void PrintLeftTreeView(TreeNode root)
        {
            var temp = root.Data;
            int maxLevelSofar = -1;
            Queue<QueueNode> nodeQueue = new Queue<QueueNode>();
            nodeQueue.Enqueue(new QueueNode(root,0));

            while (nodeQueue.Count>0)
            {
                var queueNode = nodeQueue.Dequeue();
                if (queueNode.level > maxLevelSofar)
                {
                    maxLevelSofar = queueNode.level;
                    Console.WriteLine(queueNode.node.Data);
                }
                if(queueNode.node.Left != null)
                {
                    nodeQueue.Enqueue(new QueueNode(queueNode.node.Left, maxLevelSofar + 1));
                }

                if (queueNode.node.Right != null)
                {
                    nodeQueue.Enqueue(new QueueNode(queueNode.node.Right, maxLevelSofar + 1));
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
            root.Right.Left = new TreeNode(6);
            root.Right.Right = new TreeNode(7);
            root.Right.Left.Right = new TreeNode(8);
            root.Right.Right.Right = new TreeNode(9);
            Console.WriteLine("Vertical Order traversal is");
            PrintLeftTreeView(root);
        }
    }
}
