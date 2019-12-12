using System;
using System.Collections.Generic;
using Utility;

namespace TwoSum
{
    class TwoSumProgram : BaseProgram
    {
        static void Main(string[] args)
        {
            int[] r = Solution.TwoSum2(nums, 10);
            PrintArray(r);
            Read();
        }
    }

    public static class Solution
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return null;
            int temp;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                temp = target - nums[i];
                for (int j = 1+i; j < nums.Length; j++)
                {
                    if (nums[j] == temp)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }

        public static int[] TwoSum1(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return null;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                dict.TryAdd(nums[i], i);
            }
            int temp;
            for (int i = 0; i < nums.Length; i++)
            {
                temp = target - nums[i];
                bool result = dict.TryGetValue(temp, out int index);
                if (result && index != i)
                {
                    return new int[] { i, index };
                }
            }
            return null;
        }

        public static int[] TwoSum2(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return null;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int temp;
            for (int i = 0; i < nums.Length; i++)
            {
                temp = target - nums[i];
                bool result = dict.TryGetValue(temp, out int index);
                if (result && index != i)
                {
                    return new int[] { index, i };
                }
                else
                {
                    dict.TryAdd(nums[i], i);
                }
            }
            return null;
        }
    }
}
