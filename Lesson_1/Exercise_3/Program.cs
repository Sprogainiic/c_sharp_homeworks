using System;

namespace Exercise_3
{
    //Exercise 3
    //Create console application that takes a number as input and print its multiplication table(from 1 to 10)
    //Example:
    //2*1=2
    //2*2=4
    //...
    //There should be check for entered number value. If entered value is not a number, error is shown and number can be entered once again.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an any nummber an I will show it's multiplication table (from 1 to 10)");
            double nummericValue = GetNumberFromConsole();

            for (int i = 1; i < 11; i++)
            {
                var result = nummericValue * i;
                Console.WriteLine(string.Format("{0}*{1}={2}", nummericValue, i, result));
            }
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
