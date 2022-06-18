using System.Text;

namespace ArraysAndStrings
{
    public class ReverseWord_InterviewCake
    {
        public static string ReverseWord(string str)
        {
            char[] chars = str.ToCharArray();
            Stack<string> stack = new Stack<string>();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != ' ')
                {
                    sb.Append(chars[i]);
                }
                else
                {
                    stack.Push(sb.ToString());
                    sb = new StringBuilder();
                }
            }

            stack.Push(sb.ToString());
            sb = new StringBuilder();

            while (stack.Count != 0)
            {
                sb.Append(stack.Pop());
                sb.Append(' ');
            }

            str = sb.ToString();

            return str;
        }

        public static string reverseWord(string str)
        {
            char[] str_Array = str.ToCharArray();
            int rightIndex = 0;
            int leftIndex = str_Array.Length - 1;
            List<int> reverseWordEndIndexs = new List<int>();

            while (rightIndex < leftIndex)
            {
                char temp = str_Array[rightIndex];
                str_Array[rightIndex] = str_Array[leftIndex];
                str_Array[leftIndex] = temp;

                if (str_Array[rightIndex] == ' ')
                    reverseWordEndIndexs.Add(rightIndex - 1);

                if (str_Array[leftIndex] == ' ')
                    reverseWordEndIndexs.Add(leftIndex - 1);

                rightIndex++;
                leftIndex--;
            }

            if (rightIndex == leftIndex && leftIndex == ' ')
                reverseWordEndIndexs.Add(rightIndex - 1);

            reverseWordEndIndexs.Add(str_Array.Length - 1);
            reverseWordEndIndexs.Sort();

            int reverseWordRightIndex = 0;
            int reverseWordLeftIndex = reverseWordEndIndexs[0];

            for (int i = 0; i < reverseWordEndIndexs.Count; i++)
            {
                if (i != 0)
                    reverseWordRightIndex = reverseWordEndIndexs[i - 1] + 2;

                reverseWordLeftIndex = reverseWordEndIndexs[i];

                while (reverseWordRightIndex < reverseWordLeftIndex)
                {
                    char temp = str_Array[reverseWordRightIndex];
                    str_Array[reverseWordRightIndex] = str_Array[reverseWordLeftIndex];
                    str_Array[reverseWordLeftIndex] = temp;

                    reverseWordRightIndex++;
                    reverseWordLeftIndex--;
                }
            }

            str = new string(str_Array);

            return str;
        }
    }
}
