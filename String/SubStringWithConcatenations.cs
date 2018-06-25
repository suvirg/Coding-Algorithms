using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems
{
    public class SubStringWithConcatenations : IQuestion
    {
        // Limitation of this solution => words should be unique...
        public List<int> FindSubStringWithConcatenations(string s, string[] Words)
        {
            List<int> resultList = new List<int>();
            int countWords = Words[0].Length;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int index = 0;
            int count = 0;
            bool bFlag = false;

            foreach (var w in Words)
            {
                dic.Add(w, 0);
            }

            for (int i = 0; i < s.Length - countWords; i = i + countWords)
            {
                string subString = s.Substring(i, countWords);
                if (dic.ContainsKey(subString))
                {
                    if (dic[subString] > 0)
                    {
                        index = i;
                    }
                    else
                    {
                        dic[subString] = 1;
                        if (!bFlag)
                        {
                            index = i;
                            bFlag = true;
                        }
                        count++;
                    }

                }

                if (count == Words.Length)
                {
                    resultList.Add(index);
                    bFlag = false;
                    count = 0;
                    foreach (var w in Words)
                    {
                        dic[w] = 0;
                    }
                }
            }

            return resultList;
        }


        public List<int> FindSubStringWithConcatenations_ver2(string s, string[] Words)
        {
            List<int> resultList = new List<int>();
            int countWords = Words[0].Length;
            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (var w in Words)
            {

                if (!dic.ContainsKey(w))
                    dic.Add(w, 1);
                else
                    dic[w] = dic[w] + 1;

            }

            for (int i = 0; i <= s.Length - countWords * Words.Length; i++)
            {
                string subString = s.Substring(i, countWords * Words.Length);
                if (isAllWords(subString, dic, countWords))
                {
                    resultList.Add(i);
                }

            }

            return resultList;

        }

        private bool isAllWords(string str, Dictionary<string, int> dic, int wordLength)
        {
            bool bflag = true;

            Dictionary<string, int> tempdic = new Dictionary<string, int>();

            tempdic = dic.ToDictionary(e => e.Key, e => e.Value);

            for (int i = 0; i <= str.Length - wordLength; i = i + wordLength)
            {
                string subString = str.Substring(i, wordLength);
                if (tempdic.ContainsKey(subString))
                {
                    tempdic[subString] = tempdic[subString] - 1;
                }
            }

            foreach (var w in tempdic)
            {
                if (w.Value > 0)
                {
                    bflag = false;
                }
            }

            return bflag;
        }


        public void Run()
        {
            //For example, given: s="barfoothefoobarman" & words=["foo", "bar"], return [0,9].
            //
            //string s = "barfoofoothefoobarfooman";

            //string[] Words = new string[] { "foo", "bar","foo" };


            //string s = "ababaab";
            //string[] Words = new string[] { "ab", "ba", "ba"};

            //var result = FindSubStringWithConcatenations(s, Words);

            //foreach (var r in result)
            //{
            //    Console.WriteLine("All Index {0}", r);
            //}

            //Console.ReadLine();
        }
    }
}
