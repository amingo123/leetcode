using System;
using System.Collections.Generic;
using Utility;

namespace _104._MaximumDepthofBinaryTree
{
    class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            TreeNode tn7 = new TreeNode(3);
            TreeNode tn6 = new TreeNode(4);
            TreeNode tn3 = new TreeNode(2, tn6, tn7);
            TreeNode tn5 = new TreeNode(4);
            TreeNode tn4 = new TreeNode(3);
            TreeNode tn2 = new TreeNode(2, tn4, tn5);
            TreeNode tn1 = new TreeNode(1, tn2, tn3);
            int i = Solution.MaxDepth(tn1);
            WriteL(i);

            tn6 = new TreeNode(5);
            tn5 = new TreeNode(4, tn6);
            tn4 = new TreeNode(3, tn5);
            tn2 = new TreeNode(2, tn4);
            tn1 = new TreeNode(1, tn2);
            i = Solution.MaxDepth(tn1);
            WriteL(i);
        }
    }

    public static class Solution
    {
        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            return Math.Max(MaxDepth(root.left) + 1, MaxDepth(root.right) + 1);
        }

        /// <summary>
        /// wrong
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MaxDepth1(TreeNode root)
        {
            if (root == null) return 0;
            List<TreeNode> list = new List<TreeNode>
            {
                root, root?.left, root?.right
            };
            int i = 1;
            TreeNode left, right;
            //wrong
            while (true) 
            {
                left = list[i];
                right = list[i + 1];
                //if (left == null && right == null) break;
                list.Add(left?.left);
                list.Add(left?.right);
                list.Add(right?.left);
                list.Add(right?.right);
                i = i + 2;
                if (i > list.Count - 1) break;
            }

            //right
            int depth = 0;            
            for (int k = list.Count - 1; k >= 0; k--)
            {
                int m = 0;                
                if (list[k] == null)
                {
                    continue;
                }

                int n = k;
                while (n > 0)
                {
                    m++;
                    n = (n - 1) / 2;
                }
                depth = Math.Max(++m, depth);
            }

            return depth;
        }        
    }
}
