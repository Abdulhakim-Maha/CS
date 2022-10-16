using System;
using System.Threading;

namespace Lab_OS_Concurrency02
{
	class Program{
		static int resouce = 10000;
		static void TestThread1(){
			// Experiment 3
			// resouce = 55555; // Experiment 3

			// Experiment 3.1
			int i;
			for (i = 0; i < 45555; i++){
				resouce++;
				System.Console.Write(".");
			}
		}

		static void Main(string[] args)
		{
			Thread th1 = new Thread(TestThread1);
			th1.Start();

			// Experiment 3.1
			// Thread.Sleep(2000);

			// Experiment 3.2
			th1.Join();
			System.Console.WriteLine("resouce={0}", resouce);
		}
	}
}
