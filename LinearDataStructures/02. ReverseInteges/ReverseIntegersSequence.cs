// 02. Write a program that reads N integers from the console and reverses them using a stack.
// Use the Stack<int> class.

namespace _02.ReverseInteges
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;

    public class ReverseIntegersSequence
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.Write("Please, enter a positive integer N (numbers of integers to be read): ");
            int numberOfIntegers;
            bool isNumberValid = int.TryParse(Console.ReadLine(), out numberOfIntegers);

            while (!isNumberValid || numberOfIntegers <= 0)
            {
                Console.WriteLine("Invalid positive integer, try again!");
                Console.Write("Please, enter a positive integer N (numbers of integers to be read): ");
                isNumberValid = int.TryParse(Console.ReadLine(), out numberOfIntegers);
            }

            var stackOfNumbers = new Stack<int>();

            for (int i = 0; i < numberOfIntegers; i++)
            {
                Console.Write("Please enter an integer: ");
                int currentNumber;
                isNumberValid = int.TryParse(Console.ReadLine(), out currentNumber);

                while (!isNumberValid)
                {
                    Console.Write("Invalid integer, try again: ");
                    isNumberValid = int.TryParse(Console.ReadLine(), out currentNumber);
                }    

                stackOfNumbers.Push(currentNumber);
            }

            Console.WriteLine("The numbers in reversed order: ");
            while (stackOfNumbers.Count > 0)
            {
                Console.WriteLine(stackOfNumbers.Pop());             
            }
        }
    }
}
