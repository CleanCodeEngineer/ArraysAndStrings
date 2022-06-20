using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public class Anagrams
    {
        //cde
        //abc
        // Complete the makeAnagram function below.
        public static int makeAnagram(string a, string b)
        {
            int deletionCount = 0;
            Dictionary<char, int> aCharacters = new Dictionary<char, int>();
            Dictionary<char, int> bCharacters = new Dictionary<char, int>();
            Dictionary<char, int> allCharacters = new Dictionary<char, int>();

            // saving characters of string a in a dictionary
            foreach (char c in a)
            {
                if (!aCharacters.ContainsKey(c))
                {
                    aCharacters.Add(c, 1); // {{c,1}, {d,1}, {e,1}}

                    if (!allCharacters.ContainsKey(c))
                        allCharacters.Add(c, 0); // {{c,0}, {d,0}, {e,0}}                
                }
                else
                {
                    aCharacters[c]++;
                }
            }

            // saving characters of string b in a dictionary
            foreach (char c in b)
            {
                if (!bCharacters.ContainsKey(c))
                {
                    bCharacters.Add(c, 1); // {{a,1}, {b,1}, {c,1}}

                    if (!allCharacters.ContainsKey(c))
                        allCharacters.Add(c, 0); // {{c,0}, {d,0}, {e,0}, {a,0}, {b,0}}
                }
                else
                {
                    bCharacters[c]++;
                }
            }

            foreach (KeyValuePair<char, int> c in allCharacters) // c , d, e, a, b
            {

                if (bCharacters.ContainsKey(c.Key) && aCharacters.ContainsKey(c.Key))
                {
                    deletionCount += Math.Abs(bCharacters[c.Key] -
                    aCharacters[c.Key]);
                }
                else if (bCharacters.ContainsKey(c.Key))
                {
                    deletionCount += Math.Abs(bCharacters[c.Key] -
                    allCharacters[c.Key]);
                }
                else if (aCharacters.ContainsKey(c.Key))
                {
                    deletionCount += Math.Abs(aCharacters[c.Key] -
                    allCharacters[c.Key]);
                }
                //{{c,0} , {d,1}

            }

            return deletionCount;
        }
    }
}
