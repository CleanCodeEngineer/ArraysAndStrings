namespace ArraysAndStrings
{
    public class LongestSubstring
    {
        // Matrix // Array // String // Dynamic Programming
        // Q3: Given two strings, write a function that returns the longest common substring.
        // eg. longestSubstring("ABAB", "BABA") = "ABA"
        // eg. longestSubstring("ABA", "BA") = "BA"
        // 2D Array (Two D Array)
        //   A B A
        // B 0 1 0
        // A 1 0 2
        public string longestSubstring(string a, string b)
        {
            string output = ""; // Empty String

            if (a.Length == 0 || b.Length == 0) return output;

            int[,] cache = new int[a.Length, b.Length];

            // Iterate through both strings
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            cache[i, j] = 1;
                        }
                        else
                        {
                            cache[i, j] = cache[i - 1, j - 1] + 1;
                        }

                        if (cache[i, j] > output.Length)
                            output = a.Substring(i - cache[i, j] + 1, cache[i, j]);
                    }
                }
            }

            return output;
        }

        // Question: Given a string s, find the length of the longest substring without repeating characters.
        // Example:
        // Input: s = "abcabcbb"
        // Output: 3
        // Explanation: The answer is "abc", with the length of 3.
        // It uses the sliding window technique — a key skill they look for.
        // It tests hashing (e.g., using a HashSet or HashMap).
        public int LengthOfLongestSubstring(string s)
        {
            HashSet<char> seen = new HashSet<char>(); // currently in our window
            int left = 0, maxLength = 0; // left index of our window, length of the longest valid window we’ve seen so far

            for (int right = 0; right < s.Length; right++)
            {
                while (seen.Contains(s[right]))
                {
                    seen.Remove(s[left]);
                    left++;
                }

                seen.Add(s[right]);
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }
    }
}
