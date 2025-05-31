
namespace ArraysAndStrings
{
    public class CheckIfStringIsValid
    {
        // String is composed of various brackets, barces and paranthesis.
        public static bool IsValid(string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;

            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>
            {
                {')', '(' },
                {'}', '{' },
                {']','[' }
            };

            foreach (char c in str)
            {
                if (bracketPairs.ContainsValue(c)) // Only push open brackets to the stack
                {
                    stack.Push(c);
                }
                else if (bracketPairs.ContainsKey(c)) // Only pop when you see a closed bracket
                {
                    if (stack.Count == 0 || stack.Pop() != bracketPairs[c])
                    {
                        return false;
                    }
                }
                else
                    continue;
            }

            return stack.Count == 0;
        }
    }
}
