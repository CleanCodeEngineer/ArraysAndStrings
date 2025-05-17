using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    public class ReturnIndicesAndIsBalanced_InterviewQuestions
    {
        // Hashmap (Dictionary)
        // Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        // You may assume that each input would have exactly one solution, and you may not use the same element twice.
        // You can return the answer in any order.
        // Example 1:
        // Input: nums = [11, 2, 13, 7], target = 9
        // Output: [1,3]
        // Output: Because nums[1] + nums[3] == 9, we return [1, 3].
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

        // Given a string containing just the characters '(', ')', '{', '}', '[', and ']', write a function to determine if the input string is valid.An input string is valid if:
        // Open brackets are closed by the same type of brackets.
        // Open brackets are closed in the correct order.
        // Each closing bracket has a corresponding open bracket of the same type.
        // Examples:
        // Input: "{[()]}"      Output: true  
        // Input: "{[(])}"      Output: false  
        // Input: "{[}"         Output: false  
        // Input: ""            Output: true  
        // Input: "([{}])"      Output: true
        public bool IsBalanced(string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;

            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            foreach (char c in input)
            {
                if (bracketPairs.ContainsValue(c))
                {
                    stack.Push(c);
                }
                else if (bracketPairs.ContainsKey(c))
                {
                    if (stack.Count == 0 || stack.Pop() != bracketPairs[c])
                    {
                        return false;
                    }
                }
                else
                {
                    // Uncomment the next line if you want to reject non-bracket characters
                    // return false;
                    continue; // or skip other characters if allowed
                }
            }
            // Return true if every opening bracket has been correctly closed and matched — otherwise, return false.
            // unmatched opening brackets — like "(((" or "{[("
            return stack.Count == 0;
        }
    }
}