using System;
using System.Diagnostics;
using System.Threading;

namespace OS_Sync_01
{
    class Program
    {
        private static string x = "";
        private static bool exitflag = false;

		private static bool entered = false;
        private static object _Lock = new Object();
        static void ThWriteX()
        {   
            while(exitflag==false){
                // lock(_Lock){
                    Monitor.Enter(_Lock);
                    Console.Write("Input: ");
                    string xx = null;  
                    xx = Console.ReadLine();
                    if(xx == "exit"){
                        exitflag = true;
                    }
                    else{
                        x = xx;
						entered = true;
                    }
                // }         
                    Monitor.Exit(_Lock);
            }
        }
        static void ThReadX()
        {
            while(exitflag==false){
                // lock(_Lock){
                    try
                    {
                        Monitor.Enter(_Lock);
                        if (!entered){
                            // System.Console.WriteLine("before throw");
                            throw new Exception();
                        }
                        if (exitflag==false){
                            Console.WriteLine("X = {0}", x);
                            Thread.Sleep(105);
                            // entered = false;
                        }
                        else if (exitflag == true){
                            Console.WriteLine("Thread 1 exit");
                        }
                    }
                    catch (System.Exception)
                    {
                        // throw;
                    }
                    finally
                    {
                        Monitor.Exit(_Lock);
                    }
                // }
            }
        }
        static void Main(string[] args)
        {
            Thread A = new Thread(ThWriteX);
            Thread B = new Thread(ThReadX);

            A.Start();
            B.Start();

            // A.Join();
            // B.Join();

        }
    }
}