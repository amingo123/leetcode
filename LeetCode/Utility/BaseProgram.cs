using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    public class BaseProgram
    {
        public static void Write(object o)
        {
            Console.Write(o);
        }

        public static void WriteL(object o)
        {
            Console.WriteLine(o);
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
    }
}
