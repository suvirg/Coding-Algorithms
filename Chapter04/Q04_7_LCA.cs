
using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter04
{
    public class Q04_7_LCA : IQuestion
    {
        const int TwoNodesFound = 2;
        const int OneNodeFound = 1;
        const int NoNodesFound = 0;

        // Checks how many “special” nodes are located under this root
        public static int Covers(TreeNode root, TreeNode p, TreeNode q)
        {
            var nodesFound = NoNodesFound;

            if (root == null)
            {
                return nodesFound;
            }
            
            if (root == p || root == q)
            {
                nodesFound += 1;
            }

            nodesFound += Covers(root.Left, p, q);

            if (nodesFound == TwoNodesFound) // Found p and q 
            {
                return nodesFound;
            }

            return nodesFound + Covers(root.Right, p, q);
        }

        public static TreeNode CommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (q == p && (root.Left == q || root.Right == q))
            {
                return root;
            }

            // Check left side
            var nodesFromLeft = Covers(root.Left, p, q); 

            if (nodesFromLeft == TwoNodesFound)
            {
                if (root.Left == p || root.Left == q)
                {
                    return root.Left;
                }
                
                return CommonAncestor(root.Left, p, q);
            }
            else if (nodesFromLeft == OneNodeFound)
            {
                if (root == p)
                {
                    return p;
                }
                else if (root == q)
                {
                    return q;
                }
            }
            
            // Check right side
            var nodesFromRight = Covers(root.Right, p, q); 

            if (nodesFromRight == TwoNodesFound)
            {
                if (root.Right == p || root.Right == q)
                {
                    return root.Right;
                }
                
                return CommonAncestor(root.Right, p, q);
            }
            else if (nodesFromRight == OneNodeFound)
            {
                if (root == p)
                {
                    return p;
                }
                else if (root == q)
                {
                    return q;
                }
            }

            if (nodesFromLeft == OneNodeFound && nodesFromRight == OneNodeFound)
            {
                return root;
            }
            
            return null;
        }

        public static Stack<TreeNode> PathToX(TreeNode root, TreeNode x)
        {
            if (root == null) return null;
            if (root.Data == x.Data)
            {
                var stack = new Stack<TreeNode>();
                stack.Push(root);
                return stack;
            }

            var leftpath = PathToX(root.Left, x);
            if(leftpath !=null)
            {
                leftpath.Push(root);
                return leftpath;
            }

            var rightpath = PathToX(root.Right, x);
            if (rightpath != null)
            {
                rightpath.Push(root);
                return rightpath;
            }

            return null;

        }

        public static TreeNode FindLCA(TreeNode root, TreeNode node1, TreeNode node2)
        {
            var pathToNode1 = PathToX(root, node1);
            var pathToNode2 = PathToX(root, node2);
            if(pathToNode1 == null && pathToNode2 == null)
            {
                return null;
            }
            TreeNode lca = null;

            while(pathToNode1.Count>0 && pathToNode2.Count > 0)
            {
                var val1 = pathToNode1.Pop();
                var val2 = pathToNode2.Pop();

                if (val1.Data == val2.Data)
                {
                    lca = val1;
                    break;
                }
             }
            return lca;

         }

        public void Run()
        {
            int[] array = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
		    var root = TreeNode.CreateMinimalBst(array);
            var n3 = root.Find(6);
            var n7 = root.Find(10);
            var res = FindLCA(root, n3, n7);
		    Console.WriteLine("Common Ancester {0}", res.Data);
        }
    }
}