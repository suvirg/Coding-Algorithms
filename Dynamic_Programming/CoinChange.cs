using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    public class CoinChange : IQuestion
    {
        //Top Down Approach....
        public int MakeChange(int[] coins, int amount)
        {
            if (amount < 1) 
                return 0;
            return coinChange(coins, amount, new int[amount]);
        }

        private int coinChange(int[] coins, int rem, int[] count)
        {
            if (rem < 0)
                return -1;

            if (rem == 0)
                return 0;

            if (count[rem - 1] != 0)
                return count[rem - 1];

            int min = int.MaxValue;

            foreach (int coin in coins)
            {
                int res = coinChange(coins, rem - coin, count);
                if (res >= 0 && res < min)
                    min = 1 + res;
            }

            count[rem - 1] = (min == int.MaxValue) ? -1 : min;

            return count[rem - 1];
        }

        public long MakeChangeRecursive(int []coin, int money)
        {
            Dictionary<string, long> dic = new Dictionary<string, long>();
            return MakeChangeRecursiveHelper(coin, money, 0, dic);

        }

        public long MakeChangeRecursiveHelper(int[] coins, int money, int index , Dictionary<string, long> memo )
        {
            if (money == 0)
                return 1;
            if(index >= coins.Length)
            {
                return 0;
            }
            string key = money + "-" + index;
            if(memo.ContainsKey(key))
            {
                return memo[key];
            }
            int amountWithCoin = 0;
            long ways= 0;
            while(amountWithCoin <= money)
            {
                int remaining = money - amountWithCoin;
                ways += MakeChangeRecursiveHelper(coins, remaining, index + 1, memo);
                amountWithCoin += coins[index];
            }
            memo.Add(key, ways);
            return ways;
        }

        public void Run()
        {
            int[] coins = new int[] { 25, 10, 5, 1 };
            int amount = 19;
            var result = MakeChangeRecursive(coins, amount);
            Console.WriteLine("Minimum Coin to return {0} is {1}", amount, result);

       }
    }
}
