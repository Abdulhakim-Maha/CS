using System;
using System.Threading;

namespace OS_Problem_02
{
    class Thread_safe_buffer
    {
        static int[] TSBuffer = new int[10];
        static int Front = 0;
        static int Back = 0;
        static int Count = 0;
        static object locker = new object();
        static int EnCount = 0;
        static int DeCount = 0;

        static void EnQueue(int eq)
        {
            TSBuffer[Back] = eq;
            Back++;
            Back %= 10;
            Count += 1;
            EnCount++;
            // Console.WriteLine("+ EnQ, Queue now = {0}, EnQ total = {1}", Count, EnCount);
        }

        static int DeQueue()
        {
            int x = 0;
            x = TSBuffer[Front];
            Front++;
            Front %= 10;
            Count -= 1;
            DeCount++;
            // Console.WriteLine("- DeQ, Queue now = {0}, DeQ total = {1}", Count, DeCount);
            return x;
        }

        static void th01()
        {
            int i;
            for (i = 1; i < 51; i++)
            {
                lock (locker)
                {
                    if (Count < 10)
                    {
                        EnQueue(i);
                    }
                    else
                    {
                        i--;
                        // continue;
                    }
                }
            }
        }

        static void th011()
        {
            int i;
            for (i = 100; i < 151; i++)
            {
                lock (locker)
                {
                    if (Count < 10)
                    {
                        EnQueue(i);
                    }
                    else
                    {
                        i--;
                        // continue;
                    }
                }
            }
        }


        static void th02(object t)
        {
            int i;
            int j;
            for (i = 0; i < 60; i++)
            {
                lock (locker)
                {
                    if (DeCount == 101) break;
                    if (Count > 0)
                    {
                        j = DeQueue();
                        Console.WriteLine("j={0} | thread:{1} | count = {2}", j, t, Count);
                    }
                    else
                    {
                        i--;
                        // continue;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(th01);
            Thread t11 = new Thread(th011);
            Thread t2 = new Thread(th02);
            Thread t21 = new Thread(th02);
            Thread t22 = new Thread(th02);

            t1.Start();
            t11.Start();
            t2.Start(1);
            t21.Start(2);
            t22.Start(3);
        }
    }
}