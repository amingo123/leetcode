using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public class BaseProgram
    {
        public readonly static int[] nums = new int[] { 2, 5, 5, 11 };
        public readonly static int[] nums1 = new int[] { -5, 0, -2, 3, -2, 1, 1, 3, 0, -5, 3, 3, 0, -1 };
        public readonly static int[] nums2 = new int[] { 13, 2, 0, -14, -20, 19, 8, -5, -13, -3, 20, 15, 20, 5, 13, 14, -17, -7, 12, -6, 0, 20, -19, -1, -15, -2, 8, -2, -9, 13, 0, -3, -18, -9, -9, -19, 17, -14, -19, -4, -16, 2, 0, 9, 5, -7, -4, 20, 18, 9, 0, 12, -1, 10, -17, -11, 16, -13, -14, -3, 0, 2, -18, 2, 8, 20, -15, 3, -13, -12, -2, -19, 11, 11, -10, 1, 1, -10, -2, 12, 0, 17, -19, -7, 8, -19, -17, 5, -5, -10, 8, 0, -12, 4, 19, 2, 0, 12, 14, -9, 15, 7, 0, -16, -5, 16, -12, 0, 2, -16, 14, 18, 12, 13, 5, 0, 5, 6 };
        public readonly static int[] nums3 = new int[] { -1, 2, 1, -4 };
        public readonly static int[] nums4 = new int[] { 2, 7, 11, 15 };
        public readonly static int[] nums5 = new int[] { 1, 0, -1, 0, -2, 2 };
        public readonly static int[] nums6 = new int[] { 2, 1, 0, -1 };
        public readonly static int[] nums7 = new int[] { 1, -2, -5, -4, -3, 3, 3, 5 };

        public static void Write(object o)
        {
            Console.Write(o+"\t");
        }

        public static void WriteL(object o)
        {
            Console.WriteLine(o);
        }

        public static void WriteL()
        {
            Console.WriteLine();
        }

        public static void Read()
        {
            Console.Read();
        }

        public static void PrintArray<T>(T[] t)
        {
            if (t == null || t.Length == 0) return;
            foreach (var item in t)
            {
                Console.WriteLine(item);
            }
        }


        public static void PrintArray<T>(IList<IList<T>> list)
        {
            if (list == null || list.Count == 0) return;
            foreach (var li in list)
            {
                foreach (var l in li)
                {
                    Write(l);
                }
                WriteL();
            }
        }

        public static int[] Sort(int[] nums)
        {
            return Utility.Sort(nums);
        }
    }
}
