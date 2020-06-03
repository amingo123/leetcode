using System;
using System.Collections.Generic;
using Utility;

namespace _104._MaximumDepthofBinaryTree
{
    class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public static class Solution
    {
        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;            
            List<TreeNode> list = new List<TreeNode>
            {
                root
            };
            //TreeNode left = root.left;
            //TreeNode right = root.right;
            //while (left != null && right != null)
            //{
            //    list.Add(left);
            //    list.Add(right);
            //    left = left.left;
            //    right = left.right;
            //}
            return 0;
        }
    }
}
