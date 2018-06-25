using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class DescComparer<T> : IComparer<T>
    {
        public int Compare(T x, T y)
        {
            return Comparer<T>.Default.Compare(y, x);
        }
    }

    public class GetRunningMedian : IQuestion
    {
        void ReBalance(SortedList<int, int> lower, SortedList<int, int> higher)
        {
            SortedList<int, int> higherHeap = lower.Count > higher.Count ? lower : higher;
            SortedList<int, int> smallerHeap = lower.Count > higher.Count ? higher : lower;

            if(higherHeap.Count - smallerHeap.Count >= 2)
            {
                smallerHeap.Add(higherHeap.ElementAt(0).Key, higherHeap.ElementAt(0).Key);
            }
        }

        void AddNumber(SortedList<int, int> lower, SortedList<int, int> bigger, int number)
        {
            if (lower.Count == 0 || number < lower.ElementAt(0).Key)
            {
                lower.Add(number, number);
            }
            else
            {
                bigger.Add(number, number);
            }
        }

        public double GetMedians(SortedList<int, int> lower, SortedList<int, int> bigger)
        {
            if (bigger.Count == lower.Count)
            {
                return ((double) (lower.ElementAt(0).Key + bigger.ElementAt(0).Key) /2);
            }
            else if (bigger.Count > 0)
               return  (double)bigger.ElementAt(0).Key;
            else
                return (double)lower.ElementAt(0).Key;
        }

        public double [] GetMedians(int []Array)
        {
            double[] median = new double[Array.Length];

            SortedList<int, int> lower = new SortedList<int, int>(new DescComparer<int>());
            SortedList<int, int> higher = new SortedList<int, int>();

            for(int i=0; i<= Array.Length-1; i++)
            {
                int number = Array[i];
                AddNumber(lower, higher, number);
                ReBalance(lower, higher);
                median[i] = GetMedians(lower, higher);
            }

            return median;
        }
      
        public void Run()
        {
            //int[] Arr = new int[] { 1, 5, 3, 7, 2, 8, 9, 10, 11, 23, 15 };
            int[] Arr = new int[] { 1, 3, 6, 4};
            var result = GetMedians(Arr);

        }
    }
}
