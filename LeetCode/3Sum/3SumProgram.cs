using System;
using System.Collections.Generic;
using Utility;
using System.Linq;

namespace _3Sum
{
    class _3SumProgram : BaseProgram
    {
        static void Main(string[] args)
        {
            IList<IList<int>> list = Solution.ThreeSum1(nums1);
            PrintArray(list);
            Read();
        }
    }

    public static class Solution
    {
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            int SUM = 0;
            nums = Utility.Utility.Sort(nums);
            IList<IList<int>> list = new List<IList<int>>();
            int length = nums.Length;
            if (nums == null || length < 3 || nums[0] > SUM) return list;
            int target = 0;
            bool result = false;
            for (int i = 0; i < length; i++)
            {
                target = SUM - nums[i];
                Dictionary<int, int> dict = new Dictionary<int, int>();
                for (int j = i + 1; j < length; j++)
                {
                    result = dict.TryGetValue(target - nums[j], out int index);
                    if (result && index != j)
                    {
                        list.Add((new int[] { nums[index], nums[j], nums[i] }).ToList());
                        while (j != length - 1 && nums[j] == nums[j + 1])
                        {
                            j++;
                        }
                    }
                    else
                    {
                        dict.TryAdd(nums[j], j);
                    }
                }

                while (i != length - 1 && nums[i] == nums[i + 1])
                {
                    i++;
                }
            }
            return list;
        }

        public static IList<IList<int>> ThreeSum1(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            int length = nums.Length;
            if (length <= 2 || nums[0] > 0)
            {
                return list;
            }
            nums = Utility.Utility.Sort(nums);
            List<int> subList = new List<int>();
            int ans = 0, current = int.MinValue, leftValue = int.MinValue, rightValue = int.MaxValue;
            for (int i = 0; i < length - 2; i++)
            {
                // 去除重复集合（List<int>），最左边（i-1）已包含集合，下一个相同值时去除
                if ((i > 0) && (nums[i] == nums[i - 1]))
                {
                    continue;
                }
                int left = i + 1, right = length - 1;
                current = nums[i];
                while (left < right)
                {
                    leftValue = nums[left];
                    rightValue = nums[right];
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
                        while (rightValue == nums[--right] && left < right)
                        {
                        }
                        while (leftValue == nums[++left] && left < right)
                        {
                        }
                    }
                    else if (ans > 0)
                    {
                        // 和大于 0，多了最大值--，right-- 去除重复值
                        while (rightValue == nums[--right] && left < right)
                        {
                        }
                    }
                    else
                    {
                        // 和小于 0，少了最小值++，left-- 去除重复值
                        while (leftValue == nums[++left] && left < right)
                        {
                        }
                    }
                }
            }
            return list;
        }
    }
}
