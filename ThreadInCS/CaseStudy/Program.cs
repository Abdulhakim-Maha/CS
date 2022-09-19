using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Problem01
{
    class Program
    {
        static byte[] Data_Global = new byte[1000000000];
        static long Sum_Global = 0;
        static int G_index = 0;



        static int ReadData()
        {
            int returnData = 0;
            FileStream fs = new FileStream("Problem01.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            try 
            {
                Data_Global = (byte[]) bf.Deserialize(fs);
            }
            catch (SerializationException se)
            {
                Console.WriteLine("Read Failed:" + se.Message);
                returnData = 1;
            }
            finally
            {
                fs.Close();
            }

            return returnData;
        }
        static long sum(int startIndex, int endIndex) // return sum of each thread in long type // take 2 argument
        {
			// Modify
			long total = 0;
			for ( int idx = startIndex; idx < endIndex ; idx++){

				if (Data_Global[idx] % 2 == 0)  // return to total instead
				{
					total -= Data_Global[idx];
				}
				else if (Data_Global[idx] % 3 == 0)
				{
					total += (Data_Global[idx]*2);
				}
				else if (Data_Global[idx] % 5 == 0)
				{
					total += (Data_Global[idx] / 2);
				}
				else if (Data_Global[idx] %7 == 0)
				{
					total += (Data_Global[idx] / 3);
				}
			}
            // Data_Global[G_index] = 0;
            // G_index++;    // comment original code out
			
			return total;
        }
        static void Main(string[] args)
        {
			// Modify
			int numberOfThread = 16;
			const int max_value = 1000000000;
			Thread[] threads = new Thread[numberOfThread];
			// List<long> sum_of_thread = new List<long>();
			long[] sum_of_thread = new long[numberOfThread];
			

// (j*(max_value/numberOfThread)),((j + 1) * (max_value/numberOfThread))
            Stopwatch sw = new Stopwatch();
            int y;

            /* Read data from file */
            Console.Write("Data read...");
            y = ReadData();
            if (y == 0)
            {
                Console.WriteLine("Complete.");
            }
            else
            {
                Console.WriteLine("Read Failed!");
            }

            /* Start */
            Console.Write("\n\nWorking...\n");
            sw.Start();
			for ( int j = 0; j < numberOfThread; j++) { //(i*(MAX_VALUE/parallelParts)),((i + 1) * (MAX_VALUE/parallelParts))
				threads[j] = new Thread(() => sum_of_thread[j] = sum((j * (max_value / numberOfThread)),((j + 1) * (max_value / numberOfThread))));
				threads[j].Start();
			}
			for ( int i = 0; i < numberOfThread; i++){
				threads[i].Join();
			}
			// Thread.join();
			// Task.WaitAll(threads.ToArray());
			// System.Console.WriteLine(threads.ToArray());
			for (int f = 0; f < sum_of_thread.Length; f++)
			{
				System.Console.WriteLine(sum_of_thread[f]);
			}
			for(int i = 0; i< sum_of_thread.Length; i++){
				Sum_Global += sum_of_thread[i];
			}
			System.Console.WriteLine(Sum_Global);
            // for (i = 0; i < 1000; i++)
            //     Console.WriteLine(sum());
            sw.Stop();

            Console.WriteLine("Done.");

            /* Result */
            Console.WriteLine("Summation result: {0}", Sum_Global);
            Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}

