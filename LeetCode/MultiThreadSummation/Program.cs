using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
            int start = 1;
            int end = 10000000;
            int max = 4000;
            int length = end / max + 1;

            //0
            stopwatch.Start();
            sum = 0;
            for (int i = 0; i <= end; i++)
            {
                sum = sum + i;
            }
            stopwatch.Stop();
            WriteL("0.普通程序运行时间:" + stopwatch.ElapsedMilliseconds + "ms result=" + sum);

            //1
            ThreadLocal<long> ticks = new ThreadLocal<long>(true);
            stopwatch.Reset();
            stopwatch.Start();
            Parallel.For(start, length, (i) =>
            {
                ticks.Value += Sum((i - 1) * max, i * max);
            });
            sum = ticks.Values.Sum() + end;
            stopwatch.Stop();
            WriteL("1.Parallel.For ThreadLocal程序运行时间:" + stopwatch.ElapsedMilliseconds + "ms result=" + sum);
            ticks = null;
            sum = 0;

            //2
            stopwatch.Reset();
            stopwatch.Start();
            Parallel.For(start, length, (i) =>
            {
                Interlocked.Add(ref sum, Sum((i - 1) * max, i * max));
            });
            //sum += end;
            stopwatch.Stop();            
            WriteL("2.Parallel.For程序运行时间 Interlocked1:" + stopwatch.ElapsedMilliseconds + "ms result=" + sum);
            sum = 0;

            //3
            stopwatch.Reset();
            stopwatch.Start();
            Parallel.For(start, length, (i) =>
            {
                if (i * max >= end)
                {
                    Interlocked.Add(ref sum, Sum((i - 1) * max, end + 1));
                }
                else
                {
                    Interlocked.Add(ref sum, Sum((i - 1) * max, i * max));
                };
            });
            stopwatch.Stop();
            WriteL("3.Parallel.For程序运行时间 Interlocked2:" + stopwatch.ElapsedMilliseconds + "ms result=" + sum);
            sum = 0;

            //4
            stopwatch.Reset();
            stopwatch.Start();
            double[] resultData = new double[end + 1];
            // created a partioner that will chunk the data
            OrderablePartitioner<Tuple<int, int>> chunkPart = Partitioner.Create(0, resultData.Length, max);
            // perform the loop in chunks
            Parallel.ForEach(chunkPart, chunkRange =>
            {
                Interlocked.Add(ref sum, Sum(chunkRange.Item1, chunkRange.Item2));
            });
            stopwatch.Stop();
            WriteL("4.OrderablePartitioner程序运行时间:" + stopwatch.ElapsedMilliseconds + "ms result=" + sum);
            Read();
        }

        static long Sum(long s, long e)
        {
            long temp=0;
            for (long i = s; i < e; i++)
            {
                temp = temp + i;
            }
            return temp;
        }
    }
}
