using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09
{
    public class Q09_4_GetSubSets : IQuestion
    {
        //Not Working...TODO Fix later.....
        public List<List<int>> Subsets(int[] S)
        {
            if (S == null)
                return null;

            List<List<int>> result = new List<List<int>>();

            for (int i = 0; i < S.Length; i++)
            {
                List<List<int>> temp = new List<List<int>>();

                //get sets that are already in result
                foreach (var a in result)
                {
                    temp.Add(new List<int>(a));
                }

                //add S[i] to existing sets
                foreach (var a in temp)
                {
                    a.Add(S[i]);
                }

                //add S[i] only as a set
                List<int> single = new List<int>();
                single.Add(S[i]);
                temp.Add(single);

                result.Concat(temp);
            }

            //add empty set
            result.Add(new List<int>());
            return result;
        }

        public void Run()
        {
            int[] set = new int[] { 1, 2, 3 };
            
            var res = Subsets(set);
            
        }
    }
}
