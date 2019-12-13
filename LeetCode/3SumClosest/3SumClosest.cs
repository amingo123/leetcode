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
            Write(Solution.ThreeSumCloset(nums2, -59));
            Read();
        }
    }

    public static class Solution
    {
        public static int ThreeSumCloset(int[] nums,int target)
        {
            int length = nums.Length;
            int returnvalue = int.MaxValue;
            if (nums == null || length < 3)
            {
                return returnvalue;
            }
            List<int> templist = nums.ToList();
            templist.Sort();
            nums = templist.ToArray();

            int result = 0, leftValue = int.MinValue, rightValue = int.MaxValue;
            int leftIndex, rightIndex;
            int gap = int.MaxValue;
            int maxInRange, minInRange;
            for (int i = 0; i < length - 2; i++)
            {
                if ((i > 0) && (nums[i] == nums[i - 1]))
                {
                    continue;
                }

                leftIndex = i + 1;
                rightIndex = length - 1;
                maxInRange = nums[i] + nums[rightIndex] + nums[rightIndex - 1];
                minInRange = nums[i] + nums[leftIndex] + nums[leftIndex + 1];

                if (maxInRange < target && Math.Abs(maxInRange - target) < Math.Abs(gap))
                {
                    gap = maxInRange - target;
                    returnvalue = maxInRange;
                }
                else if (minInRange > target && Math.Abs(minInRange - target) < Math.Abs(gap))
                {
                    gap = minInRange - target;
                    returnvalue = minInRange;
                }
                else
                {
                    while (leftIndex < rightIndex)
                    {
                        leftValue = nums[leftIndex];
                        rightValue = nums[rightIndex];
                        result = nums[i] + leftValue + rightValue;
                        if (result == target)
                        {
                            return result;
                        }
                        else if (result > target)
                        {
                            if (Math.Abs(gap) > Math.Abs(result - target))
                            {
                                gap = result - target;
                                returnvalue = result;
                            }

                            if (nums[i] > target && nums[i] >= 0) return returnvalue;

                            // 和大于 0，多了最大值--，right-- 去除重复值
                            while (rightValue == nums[--rightIndex] && leftIndex < rightIndex)
                            {
                            }
                        }
                        else
                        {
                            if (Math.Abs(gap) > Math.Abs(result - target))
                            {
                                gap = result - target;
                                returnvalue = result;
                            }

                            // 和小于 0，少了最小值++，left-- 去除重复值
                            while (leftValue == nums[++leftIndex] && leftIndex < rightIndex)
                            {
                            }
                        }
                    }
                }
            }
            return returnvalue;
        }
    }
}
