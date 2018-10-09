using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    public class RomanNumeralHelpers
    {
        public static bool IsRoman(string input)
        {
            return false;
        }



        public static bool IsNumeral(string input)
        {
            int numeral;
            return int.TryParse(input, out numeral);
        }
    }
}
