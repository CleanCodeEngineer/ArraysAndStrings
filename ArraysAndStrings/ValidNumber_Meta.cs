namespace ArraysAndStrings
{
    // IsValidNumber("123")        // true
    // IsValidNumber(" 3.14 ")     // true
    // IsValidNumber("-2.7e10")    // true
    // IsValidNumber("e3")         // false
    // IsValidNumber(".")          // false
    // IsValidNumber("1e")         // false
    // IsValidNumber("1e+4.5")     // false  (you cannot have a decimal point after e (or E) in a valid number)
    // The e (or E) represents scientific notation, where the number after e is the exponent — and exponents must be integers (positive or negative), not decimals.
    // 1e10 = 1×10^10 , 2.5e3 = 2.5×10^3 , -1.2e-4 = −1.2×10^-4
    public class ValidNumber_Meta
    {
        public bool IsValidNumber(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;

            s = s.Trim();
            int n = s.Length;
            bool seenDigit = false, seenDot = false, seenE = false;

            for (int i = 0; i < n; i++)
            {
                char c = s[i];

                if (char.IsDigit(c))
                {
                    seenDigit = true;
                }
                else if (c == '+' || c == '-')
                {
                    // sign is valid only at beginning or after 'e'
                    if (i != 0 && s[i - 1] != 'e' && s[i - 1] != 'E') // Allow sign after e like "1e-10"
                        return false;
                }
                else if (c == '.')
                {
                    if (seenDot || seenE)
                        return false;
                    seenDot = true;
                }
                else if (c == 'e' || c == 'E') // Allow exponential form with e or E, e.g. "1e10"
                {
                    if (seenE || !seenDigit) 
                        return false;
                    seenE = true;
                    seenDigit = false; // must have digits after 'e' (Make sure there's a digit after e, and at least one digit in total.)
                }
                else
                {
                    return false;
                }
            }

            return seenDigit;
        }
    }
}
