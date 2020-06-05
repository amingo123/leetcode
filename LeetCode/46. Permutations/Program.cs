using System;
using System.Collections.Generic;
using Utility;

namespace _46._Permutations
{
    class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 2, 3 };
            var i = Solution.Permute(a);
            Console.WriteLine("Hello World!");
        }
    }

    public static class Solution
    {
        static readonly IList<IList<int>> list = new List<IList<int>>();
        static readonly List<int> track = new List<int>();
        public static IList<IList<int>> Permute(int[] nums)
        {
            if (nums == null || nums.Length == 0) return list;
            Backtrack(nums);
            return list;
        }

        // 路径：记录在 track 中
        // 选择列表：nums 中不存在于 track 的那些元素
        // 结束条件：nums 中的元素全都在 track 中出现
        static void Backtrack(int[] nums)
        {
            // 触发结束条件
            if (track.Count == nums.Length)
            {
                list.Add(new List<int>(track));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                // 排除不合法的选择
                if (track.Contains(nums[i])) continue;
                // 做选择
                track.Add(nums[i]);
                // 进入下一层决策树
                Backtrack(nums);
                // 取消选择
                track.RemoveAt(track.Count - 1);
            }
        }
    }
}
