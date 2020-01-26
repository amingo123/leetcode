using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Utility;


namespace MultiThreadSummation
{
    class Program : BaseProgram
    {
        static long sum = 0;
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间
            int start = 1;
            int end = 10000000;
            int max = 4000;
            int length = end / max + 1;
            ThreadLocal<long> ticks = new ThreadLocal<long>(true);
            Parallel.For(start, length, (i) =>
            {

                //1
                //Interlocked.Add(ref sum, Sum((i - 1) * max, i * max));

                //2
                //if (i * max >= end)
                //{
                //    Interlocked.Add(ref sum, Sum((i - 1) * max , end +1));
                //}
                //else
                //{
                //    Interlocked.Add(ref sum, Sum((i - 1) * max, i * max));
                //}

                //3
                ticks.Value += Sum((i - 1) * max, i * max);
            });
            //sum += end;
            sum = ticks.Values.Sum() + end;
            stopwatch.Stop();
            WriteL("Parallel.For程序运行时间:" + stopwatch.ElapsedMilliseconds + "ms result=" + sum);

            //stopwatch.Start();
            //sum = 0;
            //for (int i = 0; i <= end; i++)
            //{
            //    sum = sum + i;
            //}
            //stopwatch.Stop();
            //WriteL("程序运行时间:" + stopwatch.ElapsedMilliseconds + "ms result=" + sum);

            Read();
        }

        static long Sum(long s, long e)
        {
            long temp=0;
            for (long i = s; i < e; i++)
            {
                temp = temp + i;
            }
            //WriteL("from " + s + " to " + e + " end. sum=" + temp);
            return temp;
        }
    }
}
