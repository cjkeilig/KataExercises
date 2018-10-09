using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            StringCalculator calculator = new StringCalculator();
            Console.WriteLine("Enter two numbers to add.\nFormat 1 - Comma Separated: 1,2 --> 3\nFormat 2 - Custom Delimited: //%\\n1%2%3%4\n\"Exit\" to terminate\n");
            string line;
            while ((line = Console.ReadLine()) != "Exit")
            {
                line = line.Replace("\\n", "\n");
                Console.WriteLine("Answer: " + calculator.Add(line).ToString());
                // TODO: have a regex expression to do validation
            }
        }
    }
}
