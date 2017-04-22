using System;

using System.Threading;

namespace Thread2
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取当前线程
            //method1("a");
            // ThreadStart ts = method1;
            //ParameterizedThreadStart ts = method1;

            //for (var i=0;i<5;i++) {
            //    Thread t = new Thread(ts);
            //    t.Start("-"+i.ToString());
            //}

            //Console.WriteLine("sy");
            //Console.ReadLine();
            ParameterizedThreadStart ts = method2;
            Thread t = new Thread(ts);
            t.Start("svyopmd");
            Console.ReadLine();

        }

        public static void method1(object x)
        {
            string y = x.ToString();
            Thread.CurrentThread.Name = "wangjia";
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId+y);
            Console.WriteLine(Thread.CurrentThread.Name + y);
            Console.WriteLine(Thread.CurrentThread.IsBackground + y);
            Console.WriteLine(Thread.CurrentThread.IsAlive + y);
            Console.WriteLine(Thread.CurrentThread.ThreadState + y);
        }

        public static void method2(object x)
        {
            string y = x.ToString();
            Thread.CurrentThread.Name = "WangJia";
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + y);
            Console.WriteLine(Thread.CurrentThread.Name+y);
            Console.WriteLine(Thread.CurrentThread.IsBackground+y);
            Console.WriteLine(Thread.CurrentThread.IsAlive + y);
            Console.WriteLine(Thread.CurrentThread.ThreadState+y);
        }

    }
}