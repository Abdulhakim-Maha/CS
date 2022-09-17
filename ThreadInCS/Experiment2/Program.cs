using System;
using System.Threading;

namespace Lab_OS_Concurrency01
{
	class Program{
		static int resouce = 10000;
		static void TestThread1(){
			System.Console.WriteLine("Thread# 1 i={0}", resouce);
		}
		static void TestThread2(){
			System.Console.WriteLine("Thread# 2 i={0}", resouce);
		}

		static void Main(string[] args)
		{
			Thread th1 = new Thread(TestThread1);
			Thread th2 = new Thread(TestThread2);
			th1.Start();
			th2.Start();
		}
	}
}