using System;
namespace ThreadSyncDemo 
{
	class Program
	{
		static Mutex _mtx = new Mutex();
		static void Main(string[] args)
		{
			// starting writer thread

			for (int i = 0; i < 5; i++)
			{
				new Thread(Write).Start();
			}
		}

		public static void Write()
		{	
			System.Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Waiting...");
			_mtx.WaitOne();
			System.Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing...");
			Thread.Sleep(5000);
			System.Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing Completed...");
			_mtx.ReleaseMutex();
		}
	}
}