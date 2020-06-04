using System;
using Utility;

namespace _100._SameTree
{
    class Program:BaseProgram
    {
        static void Main(string[] args)
        {
            TreeNode tn2 = new TreeNode(5);
            TreeNode tn3 = new TreeNode(15);
            TreeNode tn1 = new TreeNode(10, tn2, tn3);

            TreeNode tn15 = new TreeNode(15);
            TreeNode tn12 = new TreeNode(5,null, tn15);
            TreeNode tn11 = new TreeNode(10, tn12);
            var i = Solution.IsSameTree(tn1, tn11);
            Console.WriteLine(i);
        }
    }

    public static class Solution
    {
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p == q) return true;
            if (p.val != q.val) return false;
            var b1 = IsSameTree(p.left, q.left);
            var b2 = IsSameTree(p.right, q.right);
            return b1 && b2;
        }
    }
}
