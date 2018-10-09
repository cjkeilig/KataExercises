using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    public class RomanNumeralConverter
    {

        private static Dictionary<char, int> romanDictionary = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }

        };

        private static Dictionary<int, string> numeralDictionary = new Dictionary<int, string>()
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };




        public string NumeralToRoman(string numeral)
        {
            string result = string.Empty;
            int number = 0;

            if (!int.TryParse(numeral, out number))
            {
                return "Bad Numeral";
            }

            foreach (var entry in numeralDictionary)
            {
                int howMany = number / entry.Key;
                for (int i = 0; i < howMany; i++)
                {
                    result += entry.Value;
                }
                number = number % entry.Key;
            }


            return result;
        }





        public string RomanToNumeral(string roman)
        {
            roman = roman.ToUpper();

            int result = 0;
            int previous = 0;
            try
            {
                for (int i = roman.Length - 1; i >= 0; i--)
                {
                    int newVal = romanDictionary[roman[i]];

                    if (newVal < previous)
                    {
                        result -= newVal;
                    }
                    else
                    {
                        result += newVal;
                        previous = newVal;
                    }
                }
            } catch (KeyNotFoundException e)
            {
                return "Bad roman numeral, use capital letters I, V, X, L, C, D, M\n";
            }


            return result.ToString();
        }
    }
}
