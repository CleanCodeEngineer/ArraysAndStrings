namespace ArraysAndStrings
{
    // Write a method to replace all spaces in a string with '%20'
    public static class URLify_Chapter1_1p3
    {
        public static string URLify(string str, int length)
        {
            //char[] str_array = str.ToCharArray();
            string[] vs = str.Trim().Split(new char[] { ' ' });

            for (int i = 0; i < vs.Length - 1; i++)
            {
                if (vs[i] != "")
                    vs[i] = vs[i] + "%20";
            }

            string url = string.Join("", vs);

            return url;
        }

        // The algorithm employs a two-scan approach. In the first scan, we count the number of spaces
        // By tripling this number, we can compute how many extra characters we will have int the final string. ' ' 1 -> '%20' 3
        // In the second pass, which is done in reverse order, we actually edit the string.
        // When we see a space, we replace it with %20. If there is no space, then we copy the original character.

        public static string URLify(string str)
        {
            // char[] str_array = str.Trim().ToCharArray();
            //int length = str_array.Length;

            return replaceSpaces(str.Trim(), str.Trim().Length);
        }

        private static string replaceSpaces(string str, int trueLength)
        {
            if (str == "")
                return null;

            int spaceCount = 0;

            for (int i = 0; i < trueLength; i++)
            {
                if (str[i] == ' ')
                    spaceCount++;
            }

            int index = trueLength + spaceCount * 2;

            char[] str_array = new char[index];

            if (trueLength < str.Length)
                str_array[trueLength] = '\0'; // End array

            for (int j = trueLength - 1; j >= 0; j--)
            {
                str_array[j] = str[j];

                if (str_array[j] == ' ')
                {
                    str_array[index - 1] = '0';
                    str_array[index - 2] = '2';
                    str_array[index - 3] = '%';
                    index = index - 3;
                }
                else
                {
                    str_array[index - 1] = str_array[j];
                    index--;
                }
            }

            string output = new string(str_array);
            return output;
        }
    }
}
