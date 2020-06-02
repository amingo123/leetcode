using System;
using Utility;

namespace _53.MaximumSubarray
{
    class Program: BaseProgram
    {
        static void Main(string[] args)
        {
            int[] a = {-1,-2 };
            int i = Solution.MaxSubArray(a);
            Write(i);
        }
    }

    public static class Solution
    {
        public static int MaxSubArray(int[] nums)
        {
            int N = nums.Length;
            if (N == 0) return 0;
            if (N == 1) return nums[0];            
            int[] dp = new int[N];            
            int result = dp[0] = nums[0];
            for (int i = 1; i < N; i++)
            {
                dp[i] = Math.Max(dp[i - 1], 0) + nums[i];
                result = Math.Max(result, dp[i]);
            }
            return result;
        }
    }
}
