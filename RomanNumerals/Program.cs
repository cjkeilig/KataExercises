using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            RomanNumeralConverter converter = new RomanNumeralConverter();
            Console.WriteLine("Enter either a number or a roman numeral and the value will be converted\n\"Exit\" to terminate\n");
            string line;
            while ((line = Console.ReadLine()) != "Exit")
            {
                string scenario;
                bool isNumeral = false;
                line = line.Replace("\\n", "\n");
                if (RomanNumeralHelpers.IsNumeral(line))
                {
                    scenario = "Converted " + line + " to roman: ";
                    isNumeral = true;
                }
                else
                {
                    scenario = "Converted " + line + " to numeral: ";
                }
                Console.WriteLine(scenario + (isNumeral ? converter.NumeralToRoman(line) : converter.RomanToNumeral(line)));
                // TODO: have a regex expression to do validation
            }
        }
    }
}
