using System;

namespace Exercise_1
{
    //Exercise 1
    //Create console application where user needs to enter name, surname and some number. 
    //Console should show following message: Hello, (Name) (Surname). You have entered number (number).
    //Press any key to exit.
    //There should be check for entered number value.If entered value is not a number, error is
    //shown and number can be entered once again.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User, Please enter your name!");
            string name = Console.ReadLine();
            Console.WriteLine(string.Format("Welcome {0}, please enter your Surname", name));
            string surname = Console.ReadLine();
            Console.WriteLine(string.Format("Hi {0} {1}, I will ask you one more thing:\nPlease enter any random number.", name, surname));

            var numberInput = GetNumberFromConsole();

            Console.WriteLine(string.Format("Thank you! You have entered {0} as your name, {1} as your surname and {2} as your chosen number.", name, surname, numberInput));
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
