using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    //Create console application which prints out the average of 4 entered numbers.

    class Program
    {
        static void Main(string[] args)
        {
            double[] numArray = new double[4];
            double sum = 0;
            double average = 0;

            Console.WriteLine("Please enter 4 numbers and I will print out average.");

            for (int i = 0; i < numArray.Length; i++)
            {
                Console.Write(string.Format("Number {0}: ", i + 1));
                numArray[i] = GetNumberFromConsole();
                sum = sum + numArray[i];
            }

            average = sum / numArray.Length;

            Console.WriteLine(string.Format("Average of entered amounts is {0}", average));
            Console.WriteLine("\nPress any key to exit.");
            Console.Read();
        }


        private static double GetNumberFromConsole()
        {
            double doubleNummber;
            while (!Double.TryParse(Console.ReadLine().Replace(",", "."), out doubleNummber))
            {
                Console.WriteLine("No, no, no! Please enter any NUMBER");
            }
            return doubleNummber;
        }
    }
}
