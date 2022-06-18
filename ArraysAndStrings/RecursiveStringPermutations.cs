namespace ArraysAndStrings
{
    // Question: Write a recursicve function for generating all permutations of an input string. Return them as a set.
    // Don't worry about time or space complexity - If we wanted efficiency, we'd write an iterative version.
    // To start, assume every character in the input string is unique.
    // Your function can have loops - it just needs to also be recursive.
    public class RecursiveStringPermutations
    {
        //  1: Input = abc, GetPermutations(abc), allCharsExceptLast = ab, lastChar = c, permutationsOfAllCharsExceptLast = { ba, ab }, permutation = cba, permutations = { cba },
        //      permutation = bca, permutations = { cba, bca }, permutation = bac, permutations = { cba, bca, bac }
        //      permutation = cab, permutations = { cba, bca, bac, cab }, permutation = acb, permutations = { cba, bca, bac, cab, acb }, permutation = abc, permutations = { cba, bca, bac, cab, acb, abc }
        //      return { cba, bca, bac, cab, acb, abc }
        //  2: Input = ab,  GetPermutations(ab),  allCharsExceptLast = a,  lastChar = b, permutationsOfAllCharsExceptLast = { a }, permutation = ba, permutations = { ba }, permutation = ab, permutations = { ba, ab },
        //      return { ba, ab }
        //  3: Input = a,   GetPermutations(a),  inputString.Length <= 1
        //      return { a }
        //  Input = a
        //  allPermutations = { abc, bca, acb, bac, cba, cab }
        public static List<string> GetPermutations(string inputString)
        {
            // Base Case
            if (inputString.Length <= 1)
                return new List<string> { inputString };

            var allCharsExceptLast = inputString.Substring(0, inputString.Length - 1);
            char lastChar = inputString[inputString.Length - 1];

            // Recursive call: get all possible permutations for all chars except last
            var permutationsOfAllCharsExceptLast = GetPermutations(allCharsExceptLast);

            // Put the last char in all posible positions for each of the above permutations
            var permutations = new List<string>();
            foreach (var permutationOfAllCharsExceptLast in permutationsOfAllCharsExceptLast)
            {
                for (int position = 0; position <= allCharsExceptLast.Length; position++)
                {
                    var permutation = permutationOfAllCharsExceptLast.Substring(0, position) + lastChar + permutationOfAllCharsExceptLast.Substring(position);

                    permutations.Add(permutation);
                }
            }

            return permutations;
        }
    }
}
