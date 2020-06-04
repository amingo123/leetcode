using System;

using System.Collections.Generic;
using System.Linq;
using Utility;

namespace _107._BinaryTreeLevelOrderTraversalII
{
    class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            TreeNode tn7 = new TreeNode(7);
            TreeNode tn6 = new TreeNode(15);
            TreeNode tn3 = new TreeNode(20, tn6, tn7);
            TreeNode tn2 = new TreeNode(9);
            TreeNode tn1 = new TreeNode(3, tn2, tn3);
            var i = Solution.LevelOrderBottom(tn1);


            tn7 = new TreeNode(5);
            tn6 = new TreeNode(4);
            tn3 = new TreeNode(3, null, tn7);
            tn2 = new TreeNode(2, tn6);
            tn1 = new TreeNode(1, tn2, tn3);
            var j = Solution.LevelOrderBottom(tn1);
            Console.WriteLine(i);
        }
    }

    public static class Solution
    {
        public static IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> lists = new List<IList<int>>();
            Level(lists, root, 0);
            return lists.Reverse().ToList();
        }

        public static void Level(IList<IList<int>> lists, TreeNode node, int level)
        {
            if (node == null) return;
            if (lists.Count == level) lists.Add(new List<int>());
            lists[level].Add(node.val);
            Level(lists, node.left, level + 1);
            Level(lists, node.right, level + 1);
        }
    }


    public static class Solution1
    {
        static Stack<List<int>> queue = new Stack<List<int>>();
        public static IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (root == null) return list;
            queue.Push(new List<int>() { root.val });
            OrderBottom(root);
            while (queue.Count > 0)
            {
                List<int> l = queue.Pop();
                list.Add(l);
            }
            return list;
        }

        private static void OrderBottom(TreeNode root)
        {
            if (root == null) return;
            if (root.left == null && root.right == null) return;
            List<int> l = new List<int>();
            if (root.left != null) l.Add(root.left.val);
            if (root.right != null) l.Add(root.right.val);
            queue.Push(l);

            OrderBottom(root.right);
            OrderBottom(root.left);
        }
    }
}
