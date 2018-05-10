using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems
{
    public class TopKFrequentWords : IQuestion
    {
        public List<String> TopKFrequentWithLINQ(String[] words, int k)
        {
            Dictionary<String, int> frequentWords = new Dictionary<String, int>();
            List<string> result = new List<string>();
            foreach (String word in  words)
            {
                if(frequentWords.ContainsKey(word))
                {
                    frequentWords[word] += 1;
                }
                else
                {
                    frequentWords.Add(word, 1);
                }
            }
            var items = from c in frequentWords orderby c.Value descending, c.Key ascending select c;
            int i = 0;

            foreach (var item in items)
            {
                i++;
                if(i<=k)
                {
                    result.Add(item.Key);
                }
            }
            return result;
        }

        public void Run()
        {
            //Find Top k occure words from the list or book.
            // input string = { "i", "love", "leetcode", "i", "love", "coding" } , k=2
            //output "i", "love";

            string[] str = new string[] { "i", "love", "leetcode", "i", "love", "coding" };
            var result = TopKFrequentWithLINQ(str, 2);
        }

        // Class for Min Heap implementation C#.
        class MinHeap<T> where T : IComparable
        {
            List<T> elements;

            public MinHeap()
            {
                elements = new List<T>();
            }
            public void Add(T item)
            {
                elements.Add(item);
                Heapify();
            }

            public void Delete(T item)
            {
                int i = elements.IndexOf(item);
                int last = elements.Count - 1;

                elements[i] = elements[last];
                elements.RemoveAt(last);
                Heapify();
            }

            public T PopMin()
            {
                if (elements.Count > 0)
                {
                    T item = elements[0];
                    Delete(item);
                    return item;
                }
                //relook at this - should we just throw exception?
                return default(T);
            }

            public void Heapify()
            {
                for (int i = elements.Count - 1; i > 0; i--)
                {
                    int parentPosition = (i + 1) / 2 - 1;
                    parentPosition = parentPosition >= 0 ? parentPosition : 0;

                    if (elements[parentPosition].CompareTo(elements[i]) > 1)
                    {
                        T tmp = elements[parentPosition];
                        elements[parentPosition] = elements[i];
                        elements[i] = tmp;
                    }
                }
            }
        }

    }
}
