using System;
using System.Threading;

namespace cv_lab
{
	class Program 
	{
		private static string x = "";
		private static int exitflag = 0;
		private static bool updateFlag = false;
		
		private static bool entered = false;

		private static Object _Lock = new Object();

		// private static Semaphore _smp = new Semaphore(1,1);
		

		static void ThReadX(object i)
		{
			while( exitflag == 0)
			{
				try
				{
					Monitor.Enter(_Lock);
					if (!entered) throw new Exception();
					if ( updateFlag == false) throw new Exception();
					if ( x != "exit")
					{
						System.Console.WriteLine($"***Thread {i} : x = {x}***)");
						updateFlag = false;
					}
					Thread.Sleep(105);
				}
				catch (System.Exception)
				{
					// throw;
				}
				finally{
					Monitor.Exit(_Lock);
				}
			}
			System.Console.WriteLine($"---Thread {i} exit---");
		}

		static void ThWriteX()
		{
			string xx;
			while( exitflag == 0){
				// lock (_Lock)
				// {
					Monitor.Enter(_Lock);
					System.Console.Write("Input: ");
					xx = System.Console.ReadLine();
					if ( xx == "exit")
						exitflag = 1;
					x = xx;
					updateFlag = true;
					entered = true;
					// Thread.Sleep(500);
				// }
					Monitor.Exit(_Lock);
			}
		}

		static void Main(string[] args)
		{
			Thread A = new Thread(ThWriteX);
			Thread B = new Thread(ThReadX);
			Thread C = new Thread(ThReadX);
			Thread D = new Thread(ThReadX);

			A.Start();
			B.Start(1);
			C.Start(2);
			D.Start(3);

		}
	}
}