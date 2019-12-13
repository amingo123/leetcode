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
        public readonly static int[] nums2 = new int[] { -1, 2, 1, -4 };
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
