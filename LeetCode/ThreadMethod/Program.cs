using System;
using System.Threading;
using Utility;

namespace ThreadMethod
{
    class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            ThreadPool
            
            Console.WriteLine("Hello World!");
        }

        static void ThreadWithCallBack(ThreadStart threadStart, Action action)
        {
            ThreadStart ts = new ThreadStart(() =>
            {
                threadStart();
                action();
            });
            Thread thread = new Thread(ts);
            thread.Start();
        }

        static Func<T> ThreadWithReturn<T>(Func<T> func)
        {
            T t = default(T);
            Thread thread = new Thread(
                new ThreadStart(() =>
                {
                    t = func();
                })
             );

            thread.Start();

            return new Func<T>(() =>
            {
                thread.Join();
                return t;
            });
        }
    }
}
