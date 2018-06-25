using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    public class RemoveInvalidParentheses : IQuestion
    {
        public List<String> RemoveInvalid(String s)
        {
            List<String> res = new List<String>();

            // sanity check
            if (s == null) return res;

            HashSet<String> visited = new HashSet<String>();
            Queue<String> queue = new Queue<String>();

            // initialize
            queue.Enqueue(s);
            visited.Add(s);

            bool found = false;

            while (queue.Count != 0)
            {
                s = queue.Dequeue();

                if (isValid(s))
                {
                    // found an answer, add to the result
                    res.Add(s);
                    found = true;
                }

                if (found) continue;

                // generate all possible states
                for (int i = 0; i < s.Length; i++)
                {
                    // we only try to remove left or right paren
                    if (s[i] != '(' && s[i] != ')') continue;

                    String t = s.Substring(0, i) + s.Substring(i + 1);

                    if (!visited.Contains(t))
                    {
                        // for each state, if it's not visited, add it to the queue
                        queue.Enqueue(t);
                        visited.Add(t);
                    }
                }
            }

            return res;
        }

        // helper function checks if string s contains valid parantheses
        bool isValid(String s)
        {
            int count = 0;
            var strArr = s.ToArray();

            for (int i = 0; i < strArr.Length; i++)
            {
                char c = strArr[i];
                if (c == '(') count++;
                if (c == ')' && count-- == 0) return false;
            }

            return count == 0;
        }


        public void Run()
        {
            string s = "()())()";
            var result = RemoveInvalid(s);
            foreach(var res in result)
            {
                Console.WriteLine(res);
            }
        }
    }
}
