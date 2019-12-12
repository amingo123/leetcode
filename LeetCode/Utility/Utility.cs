using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Utility
{
    public static class Utility
    {
        public static int[] Sort(int[] nums)
        {
            List<int> templist = nums.ToList();
            templist.Sort();
            nums = templist.ToArray();
            return nums;
        }
    }
}
