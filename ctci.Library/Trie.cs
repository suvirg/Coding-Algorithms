using System;
using System.Collections.Generic;
using System.Text;

namespace CodingAlgorithms.Library
{
    public class Trie
    {
        // The root of this trie.
        private readonly TrieNode _root;

        /* Takes a list of strings as an argument, and constructs a trie that stores these strings. */
        public Trie(List<string> list)
        {
            _root = new TrieNode();
            foreach (string word in list) {
                _root.AddWord(word);
            }
        }


        /* Takes a list of strings as an argument, and constructs a trie that stores these strings. */
        public Trie(string[] list)
        {
            _root = new TrieNode();
            foreach (string word in list) {
                _root.AddWord(word);
            }
        }

        /* Checks whether this trie contains a string with the prefix passed
         * in as argument.
         */
        public bool Contains(string prefix, bool exact)
        {
            TrieNode lastNode = _root;
            int i = 0;
            for (i = 0; i < prefix.Length; i++)
            {
                lastNode = lastNode.GetChild(prefix[i]);
                if (lastNode == null)
                {
                    return false;
                }
            }
            return !exact || lastNode.Terminates;
        }

        public bool Contains(String prefix)
        {
            return Contains(prefix, false);
        }

        public List<String> Search(String prefix)
        {
            List<String> result = new List<string>();
            List<char> charresult = new List<char>();
            StringBuilder sb = new StringBuilder();
            TrieNode lastNode = _root;
            int i = 0;
            for (i = 0; i < prefix.Length; i++)
            {
                lastNode = lastNode.GetChild(prefix[i]);
                if (lastNode == null)
                {
                    return null;
                }
                else
                    sb.Append(lastNode.Character);
            }
            result.Add(sb.ToString());
            findAllChildWords(lastNode, sb);
            result.Add(sb.ToString());
            return result;
        }

        private void findAllChildWords(TrieNode n, StringBuilder results)
        {
            if (n.Terminates) results.Append(n.Character);
            foreach (var c in n._children)
            {
                findAllChildWords(n._children.First.Value, results);
            }
        }
    }
}
