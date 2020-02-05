using System;
using System.Threading;
using System.Threading.Tasks;
using Utility;

namespace TaskAsync
{
    class Program : BaseProgram
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("main start");
            dojob();
            WriteL("main end");
            Read();
        }

        static async Task dojob()
        {
            Console.WriteLine("dojob start");
            Task t = test();
            //t.Wait();//阻塞 
            await t;//非阻塞 调用该方法的线程会继续执行
            WriteL("dojob end");
        }

        static async Task test()
        {
            Task t = new Task(() =>
            {
                WriteL("task start");

                Thread.Sleep(2000);

                WriteL("task end");
            });
            t.Start();
           await t;
        }
    }
}
