namespace ArraysAndStrings
{
    // Cracking the Coding Interview
    // Question: Assume you have a method isSubstring() which checks if one word is a substring of another.
    // Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one call to isSubstring
    public class IsRotation_Chapter1_1p9
    {
        // waterbottle is a rotation of erbottlewat
        // waterbottlewaterbottle
        // In C#, string.Contains() plays the role of isSubstring():
        public static bool IsRotation(string s1, string s2)
        {
            int len = s1.Length;
            /* Check that s1 and s2 are equal length and not empty */
            if (len == s2.Length && len > 0)
            {
                /* Concatenate s1 and s1 within new buffer */
                string s1s1 = s1 + s1;
                return s1s1.Contains(s2); // <- This is your single call to isSubstring
            }

            return false;
        }
    }
}
