using System;
using Utility;

namespace _718._MaximumLengthofRepeatedSubarray
{
    class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 2, 1 };
            int[] b = { 3, 2, 1, 4, 1 };
            int i = Solution.FindLength(a,b);
            Write(i);
        }
    }

    public static class Solution
    {
        public static int FindLength(int[] A, int[] B)
        {
            // memo keeps track of whenever A[i]==B[j] and updates current max lenghth
            // for repeated-consective match we must add memo[i+1][j+1] +1 to memo[i][j] 
            int[,] memo = new int[A.Length + 1, B.Length + 1];
            int length = 0;
            for (int i = A.Length - 1; i >= 0; i--)
            {
                for (int j = B.Length - 1; j >= 0; j--)
                {
                    if (A[i] == B[j])
                    {
                        memo[i, j] = memo[i + 1, j + 1] + 1;
                        if (memo[i, j] > length)
                            length = memo[i, j];
                    }
                }
            }

            return length;
        }
    }
}
