
namespace ArraysAndStrings
{
    public class CheckParenthesis
    {
        // Question: Given a string and the position of an opening parenthesis '(', write a function to find the position of the corresponding closing parenthesis ')'.
        // sentence: "Sometimes (when I nest them (my parentheticals) too much (like this (and this))) they get confusing."
        // Complexity: O(n) time, where n is the number of chars in the string. O(1) space.
        public static int FindClosingPosition(string sentence, int openPosition)
        {
            int openCounts = 1;
            int index = openPosition + 1;

            while (index < sentence.Length)
            {
                if (sentence[index] == '(')
                    openCounts++;
                else if (sentence[index] == ')')
                    openCounts--;

                if (openCounts == 0)
                    return index;

                index++;
            }

            return -1; // Not found
        }
    }
}
