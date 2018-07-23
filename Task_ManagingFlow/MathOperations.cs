using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_ManagingFlow
{
    public class MathOperations
    {
        public static double FindVariationRange(double min, double max)
        {
            return max - min;
        }

        public static double FindLengthInterval(double range, int numberOfIntervals)
        {
            return range / numberOfIntervals;
        }

        public static double[] FormingPartialIntervals(double[] array, int numberOfIntervals)
        {
            double range = FindVariationRange(array.Min(), array.Max());
            double[] intervals = new double[numberOfIntervals + 1];
            intervals[0] = array.Min();
            for (int i = 1; i < numberOfIntervals + 1; i++)
            {
                intervals[i] = intervals[i - 1] + FindLengthInterval(range, numberOfIntervals);
            }
            return intervals;
        }

        public static double[] FindMidpointsOfIntervals(double[] intervals)
        {
            double[] midpoints = new double[intervals.Length - 1];
            for (int i = 0; i < intervals.Length - 1; i++)
            {
                midpoints[i] = (intervals[i] + intervals[i + 1]) / 2;
            }
            return midpoints;
        }

        public static double[] FindIntervalFrequency(double[] array, double[] intervals)
        {
            Array.Sort(array);
            double[] frequencies = new double[intervals.Length - 1];
            int i = 0, j = 0;
            do
            {
                labelA:
                if (j < array.Length && array[j] >= intervals[i] && array[j] <= intervals[i + 1])
                {
                    frequencies[i]++;
                    j++;
                    goto labelA;
                }
                else i++;

            } while (i < intervals.Length - 1);
            return frequencies;
        }

        public static double[] FindRelativeFrequency(double[] frequencies)
        {
            double[] relatives = new double[frequencies.Length];
            for (int i = 0; i < frequencies.Length; i++)
            {
                relatives[i] = frequencies[i] / 100;
            }
            return relatives;
        }

        public static double[] FindDistributionDensity(double[] relatives, double length)
        {
            double[] density = new double[relatives.Length];
            for (int i = 0; i < relatives.Length; i++)
            {
                density[i] = relatives[i] / length;
            }
            return density;
        }
    }
}
