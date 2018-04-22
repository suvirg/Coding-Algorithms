using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problem
{
    public class FindUniqueWords : IQuestion
    {
        public static string Find(string inputStr)
        {
            string[] strList = inputStr.Split(' ');
            StringBuilder sb = new StringBuilder();

            Dictionary<string, List<string>> strDic = new Dictionary<string, List<string>>();

            foreach (var s in strList)
            {
                var strwithoutdup = RemoveDuplicate.RemoveDuplicateFromString(s).ToLower();
                if (strDic.ContainsKey(SortString.Sort(strwithoutdup)))
                {
                    strDic[SortString.Sort(strwithoutdup)].Add(s);
                }
                else
                {
                    strDic.Add(SortString.Sort(strwithoutdup), new List<string> { s });
                }
            }

            foreach (var dic in strDic)
            {
                if (dic.Value.Count > 1)
                {
                    foreach (var s in dic.Value)
                    {
                        sb.Append(s);
                        sb.Append("  ");
                        sb.Append("\n");
                    }
                }

            }

            return sb.ToString();

        }

        public void Run()
        {
            //Given a list of words with lower and upper cases. Implement a function to find all Words that have the same unique character set . 

            //Input
            //May student students dog studentssess  god  Cat act tab bat flow wolf lambs  Amy Yam balms looped poodle john alice
            //output
            //may amy student students studentssess dog god cat act flow wolf lambs balms looped poodle.


            string inputStr = "May student students dog studentssess god Cat act tab bat flow wolf lambs Amy Yam balms looped poodle john alice";

            var res = Find(inputStr);

            Console.WriteLine("Input String {0}", inputStr);

            Console.WriteLine("All Unique Words {0}", res);

            Console.ReadLine();

        }
    }
}
