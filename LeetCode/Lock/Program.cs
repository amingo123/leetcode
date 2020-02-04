using System;
using System.Threading;
using System.Threading.Tasks;
using Utility;

namespace Lock
{
    //线程同步方案：
    //1.lock
    //2.线程安全集合
    //3.原子引用
    //4.数据拆分，避免多线程操作
    class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            //不要lock null
            //不要lock this
            //不要lock string
            lockthis lockthis = new lockthis();
            //Task.Delay(2000).ContinueWith( _ =>
            //{
            //    lockthis.test();
            //});

            lockthis.test();

            for (int i = 0; i < 10; i++)
            {
                int k = i;
                Task t = new Task(()=>
                {
                    Thread.Sleep(1000);
                    lock (lockthis)
                    {
                        WriteL($"task {k}");
                    }
                });
                t.Start();
            }

            Read();
        }
    }

    class lockthis
    {
        public void test()
        {            
            lock (this)
            {
                Random random = new Random();
                if (random.Next(1, 100) > 93)
                {
                    return;
                }

                Console.WriteLine("test");
            }
            test();
        }
    }
}
