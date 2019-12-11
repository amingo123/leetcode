using System;
using Utility;

namespace TwoSum
{
    class Program: BaseProgram
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { };
            int[] r = Solution.TwoSum(nums, 9);
            PrintArray(r);
            Read();
        }
    }

    public static class Solution
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            return null;
        }
    }
}
