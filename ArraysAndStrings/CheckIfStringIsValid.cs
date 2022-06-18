
namespace ArraysAndStrings
{
    public class CheckIfStringIsValid
    {
        // String is composed of various brackets, barces and paranthesis.
        public static bool IsValid(string str)
        {
            if (str == null)
                return true;

            if (str.Length % 2 != 0)
                return false;

            char[] str_array = str.ToCharArray();

            Stack<char> chars = new Stack<char>();

            for (int i = 0; i < str_array.Length; i++)
            {
                if (str_array[i] == '(' || str_array[i] == '[' || str_array[i] == '{')
                {
                    chars.Push(str_array[i]);
                }

                if (str_array[i] == ')' || str_array[i] == ']' || str_array[i] == '}')
                {
                    var topChar = chars.Pop();

                    if((str_array[i] == ')' && topChar == '(') || (str_array[i] == ']' && topChar == '[') || (str_array[i] == '}' && topChar == '{'))
                    {
                        // true
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
