using System.Text;

namespace ArraysAndStrings
{
    public static class IsUnique_Chapter1_1p1
    {
        // 1.1: Implement an algorithm to determine if a string has all unique characters. What if you cannot use additional data structures?
        // Hints: #44: Try a Hash Table
        public static bool IsUnique1(string str)
        {
            HashSet<char> list = new HashSet<char>();

            foreach (char ch in str)
            {
                if (list.Contains(ch))
                    return false;
                else
                    list.Add(ch);
            }

            return true;
        }

        // Hints: #117: Could a bit vector be useful?
        public static bool IsUnique2(string str)
        {
            string sortedStr = Sort(str);

            for (int i = 0; i < sortedStr.Length; i++)
            {
                if (i + 1 < sortedStr.Length && sortedStr[i] == sortedStr[i + 1])
                    return false;
            }

            return true;
        }

        // Hints: #132: Can you solve it in O(N log N) time? What might a solution like that look like?
        public static bool IsUnique4(string str)
        {
            // O(nlgn)
            string sortedStr = mergeSort(str);

            // O(nlgn)
            for (int i = 0; i < sortedStr.Length; i++)
            {
                char currentCh = sortedStr[i];

                char[] strArray = str.ToArray();

                if (binarySearch(strArray, currentCh) != i && binarySearch(strArray, currentCh) != -1)
                    return false;
            }

            return true;
        }

        private static string mergeSort(string str)
        {
            char[] strArray = str.ToArray();

            return mergeSort(strArray, 0, str.Length - 1);
        }

        private static string mergeSort(char[] strArray, int left, int right)
        {
            if (left != right)
            {
                int mid = (left + right) / 2;

                mergeSort(strArray, left, mid);
                mergeSort(strArray, mid + 1, right);
                merge(strArray, left, mid, right);
            }


            string str = new string(strArray);

            return str;
        }

        private static void merge(char[] strArray, int left, int mid, int right)
        {
            char[] strArrayL = new char[mid + 1];
            char[] strArrayR = new char[right - mid];

            for (int i = 0; i < mid + 1; i++)
                strArrayL[i] = strArray[i];

            for (int j = 0; j < right - mid; j++)
                strArrayR[j] = strArray[j + mid + 1];

            int n = 0;
            int m = 0;
            int k = 0;

            while (n < mid + 1 && m < right - mid)
            {
                if (strArrayL[n] < strArrayR[m])
                {
                    strArray[k] = strArrayL[n];
                    k++;
                    n++;
                }
                else
                {
                    strArray[k] = strArrayR[m];
                    k++;
                    m++;
                }
            }

            for (int x = n; x < strArrayL.Length; x++)
            {
                strArray[k] = strArrayL[x];
                k++;
            }
        }

        private static int binarySearch(char[] strArray, char x)
        {
            int low = 0;
            int high = strArray.Length - 1;
            int mid;

            while (low <= high)
            {
                mid = (low + high) / 2;

                if (strArray[mid] < x)
                {
                    low = mid + 1;
                }
                else if (strArray[mid] > x)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1; // Error
        }

        // Time Complexity: O(n^2)
        // Bubble Sort
        public static string Sort(string str)
        {
            for (int j = 0; j < str.Length; j++)
            {
                char currentChar = str[j];

                if (j + 1 < str.Length)
                {
                    for (int i = j + 1; i < str.Length; i++)
                    {
                        if (str[i] <= currentChar)
                        {
                            str = ExchangeCharAt(str, j, i);
                        }
                    }
                }
            }

            return str;
        }

        public static string ExchangeCharAt(string str, int n, int m)
        {
            StringBuilder sb = new StringBuilder(str);

            char ch = sb[n];
            sb[n] = sb[m];
            sb[m] = ch;
            str = sb.ToString();

            return str;
        }

        // Time Complexity: O(n^2)
        public static bool IsUnique3(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                char currentChar = str[i];

                for (int j = 0; j < str.Length; j++)
                {
                    if (i != j && str[j] == currentChar)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}