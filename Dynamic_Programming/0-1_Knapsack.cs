using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming 
{
    public class _0_1_Knapsack : IQuestion
    {

        // Example from IDeserve-https://www.youtube.com/watch?v=ipRGyCcbrGs&t=700s
        // Not working for all cases....
        int KnapSack(int w, int[] weight, int n, int[] val)
        {
            if (w == 0 || n == weight.Length)
                return 0;
            if (weight[n] > w)
                return KnapSack(w, weight, n + 1, val );

            int included_item = val[n] + KnapSack(w - weight[n], weight, n + 1, val);
            int excluded_item = KnapSack(w, weight,  n + 1, val);


            return Math.Max(included_item, excluded_item);
        }

        //========================================================================

        int KnapSack2(int W, int[] wt, int[] val, int n)
        {
            // Base Case
            if (n == 0 || W == 0)
                return 0;

            // If weight of the nth item is more than Knapsack capacity W, then
            // this item cannot be included in the optimal solution
            if (wt[n - 1] > W)
                return KnapSack2(W, wt, val, n - 1);

            // Return the maximum of two cases: 
            // (1) nth item included 
            // (2) not included
            else
                return Math.Max(val[n - 1] + KnapSack2(W - wt[n - 1], wt, val, n - 1),
                             KnapSack2(W, wt, val, n - 1)
                           );
        }

        int knapSack_optimized(int capacity, int[] weight, int[] value, int itemsCount)
        {
            int[,] K = new int[itemsCount + 1, capacity + 1];

            for (int i = 0; i <= itemsCount; ++i)
            {
                for (int w = 0; w <= capacity; ++w)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (weight[i - 1] <= w)
                        K[i, w] = Math.Max(value[i - 1] + K[i - 1, w - weight[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[itemsCount, capacity];
        }

        public void Run()
        {
            int [] val = new int [] { 60, 100, 120 };
            int [] wt = new int [] { 10, 20, 30 };
            int W = 50;
            int n = val.Length-1;
            var result = KnapSack(W, wt, n, val);
            //var result = KnapSack2(W, wt, val, n);
            //var result =  knapSack_optimized(W, wt, val, n);
            Console.WriteLine("KnapSack Value is {0}", result);
        }
    }
}
