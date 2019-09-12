using System;

namespace Exercise_2
{
    //Exercise 2
    //Create console application the user need to enter two numbers.Application should mutually
    //exchange the values of the variables and show the result.

    class Program
    {
        static void Main(string[] args)
        {
            double number1, number2, temp;
            Console.WriteLine("Hi, I will mutually exchange the values of the two nummeric variables and show the result");

            Console.Write("Please input First Number: ");
            number1 = GetNumberFromConsole();

            Console.Write("Please input the Second Number: ");
            number2 = GetNumberFromConsole();

            temp = number1;
            number1 = number2;
            number2 = temp;

            Console.WriteLine(string.Format("Result after exchange: First Number is {0} and Second Number is {1}", number1, number2));
            Console.WriteLine("\nPress any key to exit.");
            Console.Read();
        }

        private static double GetNumberFromConsole()
        {
            double doubleNummber;
            while(!Double.TryParse(Console.ReadLine().Replace(",","."), out doubleNummber))
            {
                Console.WriteLine("No, no, no! Please enter any NUMBER");
            }
            return doubleNummber;
        }
    }
}
