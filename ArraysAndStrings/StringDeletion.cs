using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    // Given a string and a dictionary HashSet, write a function to determine the minimum number of characters to delete to make a word.
    // eg.
    // dictionary:["a","aa","aaa"]
    // query: "abc"

    // output: 2

    public class StringDeletion
    {
        public int delete(string query, HashSet<string> dictionary)
        {
            Queue<string> queue = new Queue<string>();
            HashSet<string> queueElements = new HashSet<string>();

            queue.Enqueue(query);
            queueElements.Add(query);

            while (queue.Count > 0)
            {
                string s = queue.Dequeue();

                queueElements.Remove(s);

                if (dictionary.Contains(s)) return query.Length - s.Length;

                for (int i = 0; i < s.Length; i++)
                {
                    string sub = s.Substring(0, i) + s.Substring(i + 1, s.Length);

                    if(queueElements.Contains(sub) && sub.Length > 0)
                    {
                        queue.Enqueue(sub);
                        queueElements.Add(sub);
                    }
                }
            }

            return -1;
        }
    }
}
