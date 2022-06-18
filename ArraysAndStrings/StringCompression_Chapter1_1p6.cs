using System.Text;

namespace ArraysAndStrings
{
    public static class StringCompression_Chapter1_1p6
    {
        // ASCII code a = 097, d = 100 .. 123, A = 65, D = 68 .. 91 (123 - 65) = 58
        // Lowercase and uppsercase letters (a - z)
        public static string StringCompression(string str)
        {
            int[] letterCount = countCompression(str);
            int outputStrCount = 0;

            foreach (int i in letterCount)
                outputStrCount += i ;

            if (outputStrCount - letterCount.Length > str.Length)
                return str;

            // It's slow because string concatenation operates in O(n^2) time.
            // We can fix this by using a StringBuilder
            StringBuilder outputStr = new StringBuilder(outputStrCount - letterCount.Length);
            int k = 0;

            for (int n = 0; n < letterCount.Length; n++)
            {
                k = k + letterCount[n] - 1;
                outputStr.Append(str[k]);
                outputStr.Append(letterCount[n].ToString());
                k++;
            }

            return outputStr.ToString();
        }

        public static int[] countCompression(string str)
        {
            int[] letterCount = new int[str.Length * 2];

            int j = 0;

            if (str != null)
                letterCount[j] = 1;

            for (int i = 1; i < str.Length; i++)
            {
                if (str[i - 1] != str[i])
                    j++;

                letterCount[j]++;
            }

            int[] output = new int[j + 1];

            int k = 0;

            while (k < j + 1)
            {
                output[k] = letterCount[k];
                k++;
            }

            return output;
        }
    }
}
