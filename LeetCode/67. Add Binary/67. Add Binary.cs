using System;
using System.Collections.Generic;
using System.Text;
using Utility;


namespace _67._Add_Binary
{
    class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            string s = Solution.AddBinary("1010", "1011");
            Write(s);
            Read();
        }
    }

    public static class Solution
    {
        public static string AddBinary(string a, string b)
        {
            StringBuilder sb = new StringBuilder();
            int carry = 0;
            for (int i = a.Length - 1, j = b.Length - 1; i >= 0 || j >= 0; i--, j--)
            {
                int total = ((i >= 0 ? a[i] - '0' : 0) + (j >= 0 ? b[j] - '0' : 0)) + carry;
                sb.Insert(0, total == 2 || total == 0 ? '0' : '1');
                carry = total > 1 ? 1 : 0;
            }
            return carry == 1 ? sb.Insert(0, 1).ToString() : sb.ToString();
        }
    }
}
