using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_ManagingFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Console.WriteLine("Input numbers count");  //Manual input
                //int n = CheckOnNegativity();
                //double[] array = new double[n];
                //for (int i = 0; i < n; i++)
                //{
                //    array[i] = Convert.ToDouble(Console.ReadLine());
                //}

                double[] array = { 16.8, 17.9, 21.4, 14.1, 19.1, 18.1, 15.1, 18.2, 20.3, 16.7 };
                int numberOfIntervals = 3;
                bool exit = false;

                while (!exit)
                {

                    Console.Clear();
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Sort set of numbers");
                    Console.WriteLine("2. Find range of variation");
                    Console.WriteLine("3. Output lower bounds of partial intervals");
                    Console.WriteLine("4. Find midpoints of partial intervals");
                    Console.WriteLine("5. Find interval frequency");
                    Console.WriteLine("6. Find relative frequency of intervals");
                    Console.WriteLine("7. Find distribution density");
                    Console.WriteLine("0. Exit");
                    int select = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (select)
                    {
                        case 1:
                            {
                                Array.Sort(array);
                                Console.WriteLine("Sorted set: ");
                                foreach (var s in array)
                                {
                                    Console.Write(s + " ");
                                }
                                Console.WriteLine();
                                Console.WriteLine("Press any button to contunue");
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Range of variation: {0}", MathOperations.FindVariationRange(array.Min(), array.Max()));
                                Console.WriteLine("Press any button to contunue");
                                Console.ReadKey();
                                break;
                            }
                        case 3:
                            {
                                double[] intervals = MathOperations.FormingPartialIntervals(array, numberOfIntervals);
                                Console.WriteLine("Lower bounds of partial intervals: ");
                                for (int i = 0; i < intervals.Length - 1; i++)
                                {
                                    Console.WriteLine("{0:0.#}", intervals[i]);
                                }
                                Console.WriteLine("Press any button to contunue");
                                Console.ReadKey();
                                break;
                            }
                        case 4:
                            {
                                double[] intervals = MathOperations.FormingPartialIntervals(array, numberOfIntervals);

                                double[] midpoints = MathOperations.FindMidpointsOfIntervals(intervals);
                                Console.WriteLine("Midpoints of intervals: ");
                                foreach (var m in midpoints)
                                {
                                    Console.WriteLine("{0:0.#}", m);
                                }
                                Console.WriteLine("Press any button to contunue");
                                Console.ReadKey();
                                break;
                            }
                        case 5:
                            {
                                double[] intervals = MathOperations.FormingPartialIntervals(array, numberOfIntervals);

                                double[] frequencies = MathOperations.FindIntervalFrequency(array, intervals);
                                Console.WriteLine("Interval frequencies: ");
                                foreach (var f in frequencies)
                                {
                                    Console.WriteLine(f);
                                }
                                Console.WriteLine("Press any button to contunue");
                                Console.ReadKey();
                                break;
                            }
                        case 6:
                            {
                                double[] intervals = MathOperations.FormingPartialIntervals(array, numberOfIntervals);
                                double[] frequencies = MathOperations.FindIntervalFrequency(array, intervals);

                                double[] relatives = MathOperations.FindRelativeFrequency(frequencies);
                                Console.WriteLine("Relative frequencies: ");
                                foreach (var r in relatives)
                                {
                                    Console.WriteLine(r);
                                }
                                Console.WriteLine("Press any button to contunue");
                                Console.ReadKey();
                                break;
                            }
                        case 7:
                            {
                                double range = MathOperations.FindVariationRange(array.Min(), array.Max());
                                double length = MathOperations.FindLengthInterval(range, numberOfIntervals);
                                double[] intervals = MathOperations.FormingPartialIntervals(array, numberOfIntervals);
                                double[] frequencies = MathOperations.FindIntervalFrequency(array, intervals);
                                double[] relatives = MathOperations.FindRelativeFrequency(frequencies);

                                double[] density = MathOperations.FindDistributionDensity(relatives, length);
                                Console.WriteLine("Distribution density: ");
                                foreach (var d in density)
                                {
                                    Console.WriteLine(d);
                                }
                                Console.WriteLine("Press any button to contunue");
                                Console.ReadKey();
                                break;
                            }
                        case 0:
                            {
                                Console.Clear();
                                Console.WriteLine("Thank u for using this software. Good luck!");
                                Console.WriteLine("Press any button to exit");
                                Console.ReadKey();
                                exit = true;
                                break;
                            }
                        default: break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        static int CheckOnNegativity()
        {
            int i = 0;
            do
            {
                var input = Console.ReadLine();
                try
                {
                    int.TryParse(input, out i);
                    if (i <= 0)
                    {
                        Console.WriteLine("Value must be more than 0");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Value must be Int32");
                }
            } while (i <= 0);
            return i;
        }
    }
}
