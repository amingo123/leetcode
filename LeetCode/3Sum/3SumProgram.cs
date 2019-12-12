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
            IList<IList<int>> list = Solution.ThreeSum(nums1);
            PrintArray(list);
            Read();
        }
    }

    class ItemEqualityComparer : IEqualityComparer<IList<int>>
    {
        public bool Equals(IList<int> x, IList<int> y)
        {
            if (x.Count != y.Count) return false;
            foreach (var item in x)
            {
                if (!y.Contains(item))
                {
                    return false;
                }
            }

            foreach (var item in y)
            {
                if (!x.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode(IList<int> obj)
        {
            int i = 0;
            foreach (var item in obj)
            {
                i += item.GetHashCode();
            }
            return i;
        }
    }

    public static class Solution
    {
        const int N = 0;
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IEnumerable<IList<int>> list = new List<IList<int>>();
            if (nums == null || nums.Length < 3) return list.ToList();
            int temp;
            List<int> templist = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                temp = N - nums[i];
                list = list.Union(TwoSum2(nums, temp, i));               
            }
            List<IList<int>> a = list.Distinct(new ItemEqualityComparer()).ToList();
            return a;
        }

        static IList<IList<int>> TwoSum2(int[] nums, int target, int startIndex)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (nums == null || nums.Length == 0) return null;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int temp;
            for (int i = startIndex + 1; i < nums.Length; i++)
            {
                temp = target - nums[i];
                bool result = dict.TryGetValue(temp, out int index);
                if (result && index != i)
                {
                    list.Add((new int[] { nums[index], nums[i], nums[startIndex] }).ToList());
                }
                else
                {
                    dict.TryAdd(nums[i], i);
                }
            }
            return list;
        }
    }
}
