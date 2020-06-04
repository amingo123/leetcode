using System;
using System.Collections;
using System.Collections.Generic;
using Utility;

namespace _108._Convert_Sorted_Array_to_Binary_Search_Tree
{
    class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { -10, -3, 0, 5, 9 };
            TreeNode tn = Solution.SortedArrayToBST(a);
            Console.WriteLine("Hello World!");
        }
    }

    public static class Solution
    {
        public static TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null) return null;
            if (nums.Length == 0) return null;

            TreeNode tn = new TreeNode(nums[0]);
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(tn);
            int j = 0;
            int l = nums.Length;
            TreeNode temp;
            while (q.Count > 0)
            {
                temp = q.Dequeue();
                if (2 * j + 1 <= l - 1)
                {
                    temp.left = new TreeNode(nums[2 * j + 1]);
                    q.Enqueue(temp.left);
                }
                else
                {
                    break;
                }

                if (2 * j + 2 <= l - 1)
                {
                    temp.right = new TreeNode(nums[2 * j + 2]);
                    q.Enqueue(temp.right);
                }
                else
                {
                    break;
                }
                j++;
            }
            return tn;
        }
    }
}