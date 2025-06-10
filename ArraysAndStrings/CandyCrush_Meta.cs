namespace ArraysAndStrings
{
    public class CandyCrush_Meta
    {
        // aaab
        // Time Complexity: O(n²) worst case
        // Space Complexity: O(n)
        public static string CandyCrushString(string s)
        {
            bool changed = true;

            while (changed)
            {
                changed = false;
                Stack<char> stack = new Stack<char>();
                int i = 0;

                while (i < s.Length)
                {
                    int j = i;

                    // Find the end of the group of the same characters
                    while (j < s.Length && s[j] == s[i])
                    {
                        j++;
                    }

                    // If group length >= 2, skip (crush)
                    if (j - i >= 2)
                    {
                        changed = true; // We crushed something
                    }
                    else
                    {
                        // Otherwise, keep it
                        stack.Push(s[i]);
                    }

                    i = j;
                }

                // Reconstruct string from stack
                char[] chars = stack.Reverse().ToArray();
                s = new string(chars);
            }

            return s;
        }
    }
}
