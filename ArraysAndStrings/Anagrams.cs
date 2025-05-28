namespace ArraysAndStrings
{
    // Problem: Make Anagram
    public class Anagrams
    {
        // cde
        // abc
        // Complete the makeAnagram function below.
        // Prompt: Given two strings, a and b, determine the minimum number of character deletions required to make the two strings anagrams of each other.
        // An anagram of a string is another string that contains the same characters, only the order of characters can be different.
        // You can delete characters from either string to make them anagrams.
        public static int makeAnagram(string a, string b)
        {
            Dictionary<char, int> characters = new Dictionary<char, int>();

            // Count frequency of characters in string a
            foreach (char c in a)
            {
                if (!characters.ContainsKey(c))
                {
                    characters[c]++;
                }
                else
                {
                    characters[c] = 1;
                }
            }

            // subtract frequency of characters in string b
            foreach (char c in b)
            {
                if (!characters.ContainsKey(c))
                {
                    characters[c]--;
                }
                else
                {
                    characters[c] = -1;
                }
            }

            int deletionCount = 0;
            foreach (var count in characters.Values) // c , d, e, a, b
            {
                deletionCount += Math.Abs(count);
            }

            return deletionCount;
        }
    }
}
