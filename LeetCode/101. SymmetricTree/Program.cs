using System;

namespace _101._SymmetricTree
{
    class Program
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
            var i = Solution.IsSymmetric(tn1);
            Console.WriteLine(i);

            tn7 = new TreeNode(3);
            tn6 = null;
            tn3 = new TreeNode(2, tn6, tn7);

            tn5 = new TreeNode(3);
            tn4 = null;
            tn2 = new TreeNode(2, tn4, tn5);

            tn1 = new TreeNode(1, tn2, tn3);
            i = Solution.IsSymmetric(tn1);
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
        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null) return false;
            return IsMirror(root.left, root.right);
        }

        public static bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;
            if (left.val != right.val) return false;
            return IsMirror(left.left, right.right) && IsMirror(left.right, right.left);
        }
    }
}
