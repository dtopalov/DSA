// 01. Write a program that reads from the console a sequence of positive integer numbers.

// The sequence ends when empty line is entered.
// Calculate and print the sum and average of the elements of the sequence.
// Keep the sequence in List<int>.

namespace _01.ReadIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class ConsoleIntegerReader
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            List<int> numbers = new List<int>();
            Console.Write("Please, enter a positive integer: ");
            string inputLine = Console.ReadLine();
            int currentNumber;

            while (inputLine != string.Empty)
            {
                if (int.TryParse(inputLine, out currentNumber) && currentNumber > 0)
                {
                    numbers.Add(currentNumber);
                }
                else
                {
                    Console.WriteLine("Not a valid positive integer, enter another");
                }
                Console.Write("Please, enter a positive integer: ");
                inputLine = Console.ReadLine();
            }

            Console.WriteLine("Sum: {0}; Average: {1}", numbers.Sum(), numbers.Average());
        }
    }
}
