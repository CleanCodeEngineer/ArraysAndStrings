using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public class IsRotation_Chapter1_1p9
    {
        // waterbottle is a rotation of erbottlewat
        // 0         10                        78
        // Length : 11
        public static bool isSubstring1(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            if (s1 == s2) return true;

            char s1FirstCharacter = s1[0];
            char s1LastCharacter = s1[s1.Length - 1];

            int i = 0;

            while (s1FirstCharacter != s2[i])
            {
                i++;
            }

            if (i == s2.Length)
                return false;
            else if ((i - 1 != -1 && s2[i - 1] == s1LastCharacter) || (i == 0 && s2[s2.Length - 1] == s1LastCharacter))
            {
                for (int j = 0; j < s1.Length; j++)
                {
                    if (i != s2.Length && s1[j] == s2[i])
                        i++;
                    else if (i == s2.Length)
                        i = 0;
                    else if (s1[j] != s2[i]) return false;
                }
            }

            return true;
        }

        public static bool isRotation(string s1, string s2)
        {
            int len = s1.Length;
            /* Check that s1 and s2 are equal length and not empty */
            if (len == s2.Length && len > 0)
            {
                /* Concatenate s1 and s1 within new buffer */
                string s1s1 = s1 + s1;
                return s1s1.Contains(s2);
            }

            return false;
        }
    }
}
