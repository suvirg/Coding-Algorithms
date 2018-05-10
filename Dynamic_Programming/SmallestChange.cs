using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    public class SmallestChange : IQuestion
    {

        private int Change(int amount, int[] coins)
        {
            int max = amount + 1;
            int[] dp = new int[amount + 1];
            for(int i =0;i<dp.Length;i++)
            {
                dp[i] = max;
            }

            dp[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }
            return dp[amount] > amount ? -1 : dp[amount];
        }


        public void Run()
        {
            int[] coins = new int[] { 1, 5, 10, 25 };
            int amount = 33;
            var result = Change(amount, coins);
            
        }
    }
}
