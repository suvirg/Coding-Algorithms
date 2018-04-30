using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09
{
    public class Q09_1_CountWays : IQuestion
    {
        public static int CountWays(int n)
        {
            if (n < 0)
            {
                return 0;
            }
            else if (n == 0)
            {
                return 1;
            }
            else
            {
                return CountWays(n - 1) + CountWays(n - 2) + CountWays(n - 3);
            }
        }
        
        public static int countWays2(int n)
        {
            int[] map = new int[n + 1];
            for (int i=0;i<map.Length;i++)
            {
                map[i] = -1;
            }
            return countWays(n, map);
        }

        public static int countWays(int n, int[] memo)
        {
            if (n < 0)
            {
                return 0;
            }
            else if (n == 0)
            {
                return 1;
            }
            else if (memo[n] > -1)
            {
                return memo[n];
            }
            else
            {
                memo[n] = countWays(n - 1, memo) + countWays(n - 2, memo) + countWays(n - 3, memo);
                return memo[n];
            }
        }
        public void Run()
        {

            int n = 5;
            //int ways = CountWays(n);
            int ways = countWays2(n);
            Console.WriteLine("Num of Ways to running up StairCase {0}", ways);
        }
    }
}
