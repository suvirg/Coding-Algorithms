using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems
{
    public class StringDelete : IQuestion
    {
        public int FindAfterDelete( string [] dict, string query)
        {
            List<string> result = new List<string>();
            HashSet<String> hashSet = new HashSet<string>();
            foreach(var str in dict)
            {
                hashSet.Add(str);
            }
            Queue<string> queue = new Queue<string>();
            HashSet<String> queueElement = new HashSet<string>();
            queue.Enqueue(query);
            queueElement.Add(query);

            while (queue.Count != 0)
            {
                var s = queue.Dequeue();
                queueElement.Remove(s);
                if (hashSet.Contains(s))
                    return query.Length - s.Length;
                for (int i = 0; i < query.Length; i++)
                {
                    string sub = s.Substring(0, i) + s.Substring(i + 1, s.Length);
                    if(!queueElement.Contains(sub) && sub.Length>0)
                    {
                        queue.Enqueue(sub);
                        queueElement.Add(sub);
                    }
                    
                }
            }
            return -1;
        }

        public void Run()
        {
            //Give a string and dictionary hashset , 
            // write a function to deterine the number of character to delete to make a word.
            // Input: { "a", "aa", "abc" };
            // query = "abc";
            // output :2

            //string[] dictionary = new string[] { "a", "aa", "aaa" };
            //string query = "abc";
            //var result = FindAfterDelete(dictionary, query);
            

        }
    }
}
