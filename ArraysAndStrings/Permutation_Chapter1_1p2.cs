namespace ArraysAndStrings
{
    // Describe what it means for two strings to be permutations of each other.
    // If two strings are permutations, then we know they have the same characters, but in different orders,
    // We should ask our interviewer if the permutation comparision is case sensitive.
    // We should ask if whitespace is significant.
    // Strings of diffrent lengths cannot be permutations of each other.
    public static class Permutation_Chapter1_1p2
    {
        public static bool CheckPermutation(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            Dictionary<char, int> myDictionary = new Dictionary<char, int>();

            foreach (char ch in str1)
            {
                bool hasValue = myDictionary.TryGetValue(ch, out int value);

                if (hasValue)
                    myDictionary[ch] = value + 1;
                else
                    myDictionary.Add(ch, 1);
            }

            foreach (char ch in str2)
            {
                bool hasValue = myDictionary.TryGetValue(ch, out int value);

                if (hasValue && value != 0)
                    myDictionary[ch] = value - 1;
                else
                    return false;
            }

            return true;
        }

        // Solution #1: Sort the strings.
        // This solution is O(N log N) time.
        public static string sort(string s)
        {
            char[] chars = s.ToCharArray();
            // Sort method is available against List objects and by default, in case of strings, it sorts those in alphabetical order.
            // In the background it uses Quicksort algorithm.
            Array.Sort(chars, 0, chars.Length);
            string str = new string(chars);

            return str;
        }

        public static bool permutation(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            //return sort(str1) == sort(str2);
            return sort(str1).Equals(sort(str2));
        }

        // Solution #2: Check if the two strings have identical character counts.
        // This solution uses some space, but is O(N) time.
        // two words with the same character counts.
        // ask interviewer about the size of the character set. We assumed that the character set was ASCII.
        public static bool permutation2(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            int[] letters = new int[128]; // Assumption

            char[] str1_array = str1.ToCharArray();

            foreach (char ch in str1_array) // count number of each char in str1.
            {
                letters[ch]++;
            }

            for (int i = 0; i < str2.Length; i++)
            {
                int ch = str2[i];
                Console.WriteLine(ch);
                letters[ch]--;

                if (letters[ch] < 0)
                    return false;
            }

            return true;
        }

    }
}
