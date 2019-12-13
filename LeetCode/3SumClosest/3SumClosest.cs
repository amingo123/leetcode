using System;
using System.Collections.Generic;
using Utility;
using System.Linq;

namespace _3SumClosest
{
    class _3SumClosest : BaseProgram
    {
        static void Main(string[] args)
        {
            Write(Solution.ThreeSumCloset(nums2, 1));
            Read();
        }
    }

    public static class Solution
    {
        public static int ThreeSumCloset(int[] nums,int target)
        {
            List<IList<int>> list = new List<IList<int>>();
            int length = nums.Length;
            if (nums == null || length < 3)
            {
                return 0;
            }
            List<int> templist = nums.ToList();
            templist.Sort();
            nums = templist.ToArray();
            List<int> subList = new List<int>();
            int ans = 0, current = int.MinValue, leftValue = int.MinValue, rightValue = int.MaxValue;
            int leftIndex, rightIndex;
            for (int i = 0; i < length - 2; i++)
            {
                if ((i > 0) && (nums[i] == nums[i - 1]))
                {
                    continue;
                }
                leftIndex = i + 1;
                rightIndex = length - 1;
                current = nums[i];
                while (leftIndex < rightIndex)
                {
                    leftValue = nums[leftIndex];
                    rightValue = nums[rightIndex];
                    ans = current + leftValue + rightValue;
                    if (ans == 0)
                    {
                        // 3者和为 0, 插入 list 数据
                        subList = new List<int>
                        {
                            current,
                            leftValue,
                            rightValue
                        };
                        list.Add(subList);
                        // right--, left++ 去除重复值
                        while (rightValue == nums[--rightIndex] && leftIndex < rightIndex)
                        {
                        }
                        while (leftValue == nums[++leftIndex] && leftIndex < rightIndex)
                        {
                        }
                    }
                    else if (ans > 0)
                    {
                        // 和大于 0，多了最大值--，right-- 去除重复值
                        while (rightValue == nums[--rightIndex] && leftIndex < rightIndex)
                        {
                        }
                    }
                    else
                    {
                        // 和小于 0，少了最小值++，left-- 去除重复值
                        while (leftValue == nums[++leftIndex] && leftIndex < rightIndex)
                        {
                        }
                    }
                }
            }
            return 0;
        }
    }
}
