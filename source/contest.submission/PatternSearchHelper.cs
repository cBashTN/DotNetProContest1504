using System;

namespace contest.submission
{
    public static class PatternSearchHelper
    {
        public static bool HasPattern(decimal num)
        {
            int[] digits = GetDigits(num);
            if (digits.Length < 6) return false;

            for (int i = 0; i < digits.Length-4; i++)
            {
                if(IsDigitPatternThere(digits, i))
                {
                    return true;
                }
            }
            return false;
        }

        public static int GetPatternPosition(decimal num)
        {
            int[] digits = GetDigits(num);

            for (int i = 0; i < digits.Length - 4; i++)
            {
                if (IsDigitPatternThere(digits, i))
                {
                    return i;
                }
            }
            return digits.Length;
        }

        public static int GetPatternDigit(decimal num)
        {
            int[] digits = GetDigits(num);

            for (int i = 0; i < digits.Length - 4; i++)
            {
                if (IsDigitPatternThere(digits, i))
                {
                    return digits[i];
                }
            }
            return 0;
        }


        private static bool IsDigitPatternThere(int[] digits, int there)
        {
            return (digits[there + 0].Equals(digits[there + 1])) &&
                   (digits[there + 1].Equals(digits[there + 2])) &&
                   (digits[there + 2].Equals(digits[there + 3]));
        }

        private static int[] GetDigits(decimal num)
        {
            num = Math.Abs(num);
            var numText = num.ToString().Replace(".", "").Replace(",", "");
            var numChars = numText.ToCharArray();
            var digits = new int[numChars.Length];
            for (var i = 0; i < numChars.Length; i++)
            {
                digits[i] = Convert.ToInt32(new string(numChars[i], 1));
            }
            return digits;
        }
    }
}