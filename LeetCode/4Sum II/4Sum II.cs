using System;
using System.Collections.Generic;
using Utility;

namespace _4Sum_II
{
    class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2 };
            int[] b = { -2, -1 };
            int[] c = { -1, 2 };
            int[] d = { 0, 2 };

            int i = Solution.FourSumCount(a, b, c, d);
            Write(i);
            Read();
        }
    }

    public static class Solution
    {
        public static int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int temp = 0;
            for (int i = 0; i < A.Length; i++)
            {
                for (int k = 0; k < B.Length; k++)
                {
                    temp = A[i] + B[k];
                    if (dict.ContainsKey(temp))
                    {
                        dict[temp] = dict.GetValueOrDefault(temp) + 1;
                    }
                    else
                    {
                        dict.Add(temp, 1);
                    }
                }
            }

            int count = 0;
            for (int i = 0; i < C.Length; i++)
            {
                for (int k = 0; k < D.Length; k++)
                {
                    temp = -1 * (C[i] + D[k]);
                    if (dict.ContainsKey(temp))
                    {
                        count += dict[temp];
                    }
                }
            }
            return count;
        }
    }
}
