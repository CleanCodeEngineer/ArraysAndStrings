using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public class ReturnIndicesAndIsBalanced_InterviewQuestions
    {
        // Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        // You may assume that each input would have exactly one solution, and you may not use the same element twice.
        // You can return the answer in any order.
        // Example 1:
        // Input: nums = [11, 2, 13, 7], target = 9
        // Output: [0,1]
        // Output: Because nums[0] + nums[1] == 9, we return [0, 1].
        // [3,2,4] target=6
        public int[] ReturnIndices(int[] arr, int target)
        {
            Dictionary<int, int> indices = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {

                int complement = target - arr[i];

                if (indices.ContainsKey(complement))
                {
                    return new int[] { indices[complement], i };
                }
                else
                {
                    indices[arr[i]] = i; // indices[3]=0 indices[2]=1 -> [1,2]
                }
            }

            return new int[] { };
        }

        public bool IsBalanced(String input)
        {
            bool isBalanced = true;
            Stack<char> s = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '{' || c == '[' || c == '(')
                {
                    s.Push(c);
                }

                if (c == '}')
                {
                    char topChar = s.Pop();

                    if (topChar != '{')
                    {
                        isBalanced = false;
                        return isBalanced;
                    }
                }

                if (c == ']')
                {
                    char topChar = s.Pop();

                    if (topChar != '[')
                    {
                        isBalanced = false;
                        return isBalanced;
                    }
                }

                if (c == ')')
                {
                    char topChar = s.Pop();

                    if (topChar != '(')
                    {
                        isBalanced = false;
                        return isBalanced;
                    }
                }
            }

            if (s.Count != 0)
            {
                isBalanced = false;
            }

            return isBalanced;
        }
    }
}
