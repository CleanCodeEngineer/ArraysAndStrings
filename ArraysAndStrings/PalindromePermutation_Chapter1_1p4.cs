namespace ArraysAndStrings
{
    // 1.4 Panlindrome Permutation: Given a string, write a function to check if is a permutation of a palindrome. 
    // A palindrome is a string (a word or phrase) that is the same forwards and backwards.
    // A permutation is a rearrangement of letters.
    // The palindrome does not need to be linited to just dictionary words.
    // EXAMPLE
    // Input:    Tact Coa
    // Output:   True (permutations: "taco cat", "atco cta", etc.)

    // EXAMPLE
    // Input:    tactcoapapa
    // Output:   True

    // We need to have an even number of almost all characters, so that half can be on one side and half can be on the other side.
    // At most one character (the middle character) can have odd count.
    // After removing all non-letter characters.
    public static class PalindromePermutation_Chapter1_1p4
    {
        public static bool PalindromePermutation(string str)
        {
            string lowercaseStr = str.ToLower();
            char[] str_array = lowercaseStr.ToCharArray();

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            for (int i = 0; i < str_array.Length; i++)
            {
                if (str_array[i] != ' ')
                {
                    if (charCount.ContainsKey(str_array[i]))
                        charCount[str_array[i]]++;
                    else
                        charCount.Add(str_array[i], 1);
                }
            }

            var oddKeys = (from x in charCount
                           where x.Value % 2 != 0
                           select x).ToList();

            if (oddKeys.Count > 1)
                return false;

            return true;
        }

        // This algorithm takes O(N) time, where N is the length of the string.
        public static bool isPermutationOfPalindrome(string phrase)
        {
            string lowercaseStr = phrase.ToLower();
            int[] table = buildCharFrequencyTable(lowercaseStr);
            return checkMaxOneOdd(table);
        }

        /* Check that no more than one character has an odd count. */
        private static bool checkMaxOneOdd(int[] table)
        {
            bool foundOdd = false;

            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] % 2 == 1)
                {
                    if (foundOdd)
                    {
                        return false;
                    }

                    foundOdd = true;
                }
            }

            return true;
        }

        public static double getCharNumber(char ch)
        {
            double a = (int)('a');
            double z = (int)('z');
            double val = (int)(ch);

            if (a <= val && val <= z)
            {
                return val - a;
            }

            return -1;
        }


        /* Count how many times each character appears. */
        private static int[] buildCharFrequencyTable(string phrase)
        {
            int[] table = new int[((int)('z') -
                                        (int)('a')) + 1];

            foreach (char ch in phrase.ToCharArray())
            {
                double x = getCharNumber(ch);

                if (x != -1)
                    table[(int)x]++;
            }

            return table;
        }

        // Solution #2
        public static bool isPermutationOfPalindrome2(string Phrase)
        {
            int countOdd = 0;

            int[] table = new int[(int)('z') - (int)('a') + 1];

            foreach (char ch in Phrase.ToLower().ToCharArray())
            {
                double x = getCharNumber(ch);

                if (x != -1)
                {
                    table[(int)x]++;

                    if (table[(int)x] % 2 == 1)
                    {
                        countOdd++;
                    }
                    else
                        countOdd--;
                }
            }

            return countOdd <= 1;
        }

        // Solution #3: Final implementation
        // This is O(N)
        // You might notice that we don't actually need to know the counts. We just need to know if the count is even or odd.
        // Think about flipping a light on/off (that is initially off). If the light winds up in the off state, we don't know how many times we flipped it, but we do know it was an even count.
        // We can use a single integer (as a bit vector). When we see a letter, we map it to an integer between 0 and 26 (assuming an English alphabet). Then we toggle the bit at that value.
        // At the end of the iteration, we check at most one bit in the integer is set to 1.
        // Picture an integer like 00010000. If we subtract 1 from the number, we'll get 00001111. 00010000 - 1 = 00001111
        // To subtract 1 from a number x, flip all the bits after the rightmost 1 bit. Finally, flip the rightmost 1 bit also to get the answer.
        // We can check that a number has exactly one 1 because we subtract 1 from it and then AND it with the new number, we should get 0.
        //                                                                                         00010000 & 00001111 = 0
        public static bool isPermutationOfPalindrome3(string phrase)
        {
            int bitVector = createBitVector(phrase);

            return bitVector == 0 || checkExactlyOneBitSet(bitVector);
        }

        /* Create a bit vector for the string. For each letter with value i, toggle the ith bit. */
        public static int createBitVector(string phrase)
        {
            int bitVector = 0;

            foreach (char ch in phrase.ToLower().ToCharArray())
            {
                int x = (int)getCharNumber(ch);

                bitVector = toggle(bitVector, x);
            }

            return bitVector;
        }

        /* Toggle the ith bit in the integer. */
        public static int toggle(int bitVector, int index)
        {
            if (index < 0) return bitVector;

            int mask = 1 << index;

            if ((bitVector & mask) == 0)
                bitVector |= mask;
            else
                bitVector &= ~mask;

            return bitVector;
        }

        /* Check that exactly one bit is set by subtracting one from the integer and 
         * Anding it with the original integer. */
        public static bool checkExactlyOneBitSet(int bitVector)
        {
            return (bitVector & (bitVector - 1)) == 0;
        }

    }
}
