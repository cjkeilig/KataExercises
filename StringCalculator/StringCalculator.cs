using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    public class StringCalculator
    {

        public int Add(string numbers)
        {

            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            int total = 0;
            string[] delimiters = GetDelimiters(numbers);

            if (numbers.StartsWith("//"))
                numbers = numbers.Substring(numbers.IndexOf("\n") + 1);

            IEnumerable<int> parsedNumbers = numbers.Split(delimiters, StringSplitOptions.None).Select(n => int.Parse(n));
            List<int> negatives = new List<int>();


            foreach (int number in parsedNumbers)
            {
                if (number < 0)
                {
                    negatives.Add(number);
                }

                if (number > 1000)
                    continue;

                total += number;

            }

            if (negatives.Count > 0)
            {
                throw new ArgumentException("Negatives not allowed, please fix: " + string.Join(", ", negatives.ToArray()));
            }

            return total;
        }



        private string[] GetDelimiters(string numbers)
        {

            if (numbers.StartsWith("//"))
            {
                int endOfDelimiter = numbers.IndexOf("\n");
                string delimiterText = numbers.Substring(2, endOfDelimiter - 2);
                if (delimiterText.StartsWith("["))
                {
                    return ParseCustomDelimiters(delimiterText);
                }
                else
                {
                    return new String[] { delimiterText, "\n" };
                }
                
            }
            else
            {
                return new String[] { ",","\n" };
            }
        }

        private string[] ParseCustomDelimiters(string delimiterText)
        {
            int i = 0;
            List<string> delimiterList = new List<string>();
            while (i < delimiterText.Length)
            {
                delimiterList.Add(delimiterText.Substring(i + 1, delimiterText.IndexOf("]", i) - i - 1));
                i = delimiterText.IndexOf("]", i) + 1;

            }
            delimiterList.Add("\n");
            return delimiterList.ToArray();
        }

    }
    
}
