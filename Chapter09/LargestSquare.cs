using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09
{
    // https://www.youtube.com/watch?v=FO7VXDfS8Gk&t=793s

    public class LargestSquare : IQuestion
    {
        public int GetLargestSquare(int[,] matrix)
        {
            int result = 0;
            var cache = matrix.Clone();






            return result;
        }


        public void Run()
        {
            int[,] matrix = new int[,] {  { 1, 1, 0, 1, 0 },
                                          { 0, 1, 1, 1, 0 },
                                          { 0, 1, 1, 1, 0 },
                                          { 0, 1, 1, 1, 1 }
                                       };

            var res = GetLargestSquare(matrix);
            Console.WriteLine("the largest rectangle is {0}", res);
        }
    }
}
