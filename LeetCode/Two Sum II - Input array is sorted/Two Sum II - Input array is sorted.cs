using System;
using Utility;

namespace Two_Sum_II___Input_array_is_sorted
{
    class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            PrintArray(Solution.TwoSum(nums4, 26));
            Read();
        }
    }

    public class Solution
    {
        public static int[] TwoSum(int[] numbers, int target)
        {
            if (numbers?.Length < 2) return null;
            int i = 0, j = numbers.Length -1, length = j,temp = 0;
            while (i < j)
            {
                temp = numbers[i] + numbers[j];
                if (temp == target)
                {
                    return new int[] { i + 1, j + 1 };
                }
                else if (temp > target)
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }
            return null;
        }
    }
}
