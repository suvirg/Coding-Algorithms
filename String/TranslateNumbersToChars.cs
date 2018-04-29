using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems
{
    public class TranslateNumbersToChars : IQuestion
    {

        public List<string> BuildSubSequenses(string subSequense)
        {
            if (subSequense.Length == 0)
            {
                return null;
            }

            if (subSequense.Length == 1)
            {
                return new List<string> { EncodeIntToString.Encode(subSequense) };
            }

            List<string> solutions = new List<string>();

            string prefix = subSequense.Substring(0, 1);

            List<string> subSolutions = BuildSubSequenses(subSequense.Substring(1));
            foreach (var subSolution in subSolutions)
            {
                solutions.Add(EncodeIntToString.Encode(prefix) + subSolution);
            }

            if (subSequense.Length >= 2)
            {
                prefix = subSequense.Substring(0, 2);
                int prefixValue = int.Parse(prefix);
                if (prefixValue >= 1 && prefixValue <= 26)
                {
                    subSolutions = BuildSubSequenses(subSequense.Substring(2));

                    if (subSolutions == null)
                    {
                        solutions.Add(EncodeIntToString.Encode(prefix));
                    }
                    else foreach (var subSolution in subSolutions)
                    {
                        solutions.Add(EncodeIntToString.Encode(prefix) + subSolution);
                    }
                }
            }

            return solutions;

        }


        public void Run()
        {
            var result = BuildSubSequenses("1234");
            foreach (var res in result)
            {
                Console.WriteLine(res);

            }
            Console.ReadLine();
        }
    }
}
