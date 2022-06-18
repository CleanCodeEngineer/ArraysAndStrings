
namespace ArraysAndStrings
{
    public class CheckParenthesis
    {
        // sentence: "Sometimes (when I nest them (my parentheticals) too much (like this (and this))) they get confusing."
        // Complexity: O(n) time, where n is the number of chars in the string. O(1) space.
        public static int FindClosingPosition(string sentence, int openPosition)
        {
            int closingPos = 0;
            int openCounts = 1;
            int index = openPosition;

            while (openCounts != 0 && index < sentence.Length)
            {
                index++;

                if (sentence[index] == '(')
                    openCounts++;
                else if (sentence[index] == ')')
                    openCounts--;
            }

            closingPos = index;

            return closingPos;
        }
    }
}
