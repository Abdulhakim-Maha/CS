using System;
namespace ThreadSyncDemo 
{
	class Program
	{
		static ManualResetEvent _mre = new ManualResetEvent(false);
		static void Main(string[] args)
		{
			// starting writer thread
			new Thread(Write).Start();

			for (int i = 0; i < 5; i++)
			{
				new Thread(Read).Start();
			}
		}

		public static void Write()
	{	
			System.Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing...");
			_mre.Reset();
			Thread.Sleep(5000);
			System.Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing Completed...");
			_mre.Set();
		}
		public static void Read()
		{
			System.Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Waiting...");
			_mre.WaitOne();
			// Thread.Sleep(2000);
			System.Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Reading Completed...");
		}
	}
}