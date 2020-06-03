using System;
using Utility;

namespace _563._BinaryTreeTilt
{
    class Program: BaseProgram
    {
        static void Main(string[] args)
        {            
            TreeNode tn2 = new TreeNode(2);
            TreeNode tn3 = new TreeNode(3);
            TreeNode tn1 = new TreeNode(1, tn2, tn3);
            int i = Solution.FindTilt(tn1);
            Console.WriteLine(i);

            tn2 = new TreeNode(2);
            tn1 = new TreeNode(1, tn2);
            i = Solution.FindTilt(tn1);
            Console.WriteLine(i);

            TreeNode tn5 = new TreeNode(5);
            tn3 = new TreeNode(3,tn5);
            TreeNode tn4 = new TreeNode(4);
            tn2 = new TreeNode(2,tn4);
            tn1 = new TreeNode(1, tn2,tn3);
            i = Solution.FindTilt1(tn1);
            Console.WriteLine(i);
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
        private static int tiltSum;

        public static int FindTilt1(TreeNode root)
        {
            tiltSum = 0;
            DFS(root);
            return tiltSum;
        }

        private static int DFS(TreeNode node)
        {
            if (node == null)
                return 0;
            int sumLeft = DFS(node.left);
            int sumRight = DFS(node.right);
            tiltSum += Math.Abs(sumLeft - sumRight);
            return node.val + sumLeft + sumRight;
        }

        public static int FindTilt(TreeNode root)
        {
            if (root == null) return 0;
            
            if (root.left == null && root.right == null)
            {
                return root.val;
            }
            int left = FindTilt(root.left);
            int right = FindTilt(root.right);
            return Math.Abs(left - right);
        }
    }
}
