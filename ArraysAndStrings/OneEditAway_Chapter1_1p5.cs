using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public static class OneEditAway_Chapter1_1p5
    {
        public static bool IsOneAWay(string str1, string str2)
        {
            int difference = str1.Length - str2.Length;

            if (difference < 0)
                difference = difference * -1;

            if (difference >= 2)
                return false;

            int length;

            if (str1.Length > str2.Length)
                length = str2.Length;
            else
                length = str1.Length;

            int differenceCount = 0;

            for (int i = 0; i < length; i++)
            {
                if (str1.Length == str2.Length)
                {
                    if (differenceCount > 1)
                        return false;
                    else if (str1[i] != str2[i])
                        differenceCount++;
                }
                else if (str1.Length > str2.Length)
                {
                    if (str1[i] == str2[i])
                        continue;
                    else if (str1[i + 1] != str2[i])
                        return false;
                }
                else if (str1.Length < str2.Length)
                {
                    if (str1[i] == str2[i])
                        continue;
                    else if (str2[i + 1] != str1[i])
                        return false;
                }
            }

            return true;
        }


        public static Boolean OneEditAway(string first, string second)
        {
            /* Length checks. */
            if (Math.Abs(first.Length - second.Length) > 1)
                return false;

            /* Get shorter and longer string. */
            String s1 = first.Length < second.Length ? first : second;
            String s2 = first.Length < second.Length ? second : first;

            int index1 = 0;
            int index2 = 0;
            Boolean foundDifference = false;

            while (index2 < s2.Length && index1 < s1.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    /* Ensure that this is the first difference found.*/
                    if (foundDifference) return false;
                    foundDifference = true;

                    if (s1.Length == s2.Length)
                    {
                        // One replace, move shorter pointer 
                        index1++;
                    }
                }
                else
                {
                    index1++; // If matching, move shorter pointer
                }

                index2++; // Always move pointer for longer string
            }

            return true;
        }
    }
}
