using System;
using System.Collections.Generic;

namespace LemonTree.Test.Business
{
    public static class Utility
    {
        /// <summary>
        /// Format the digit as textual representation, i.e. NNN-NNNN
        /// </summary>
        /// <param name="phoneDigits"></param>
        /// <returns></returns>
        public static string Get7DigitPhoneNumber(List<int> phoneDigits)
        {
            if (phoneDigits == null) throw new ArgumentNullException(nameof(phoneDigits));

            var phoneNumberText = string.Empty;
            for (var n = 0; n < phoneDigits.Count; n++)
            {
                phoneNumberText += phoneDigits[n].ToString();
                if (n == 2) phoneNumberText += "-";
            }
            return phoneNumberText;
        }
    }
}
