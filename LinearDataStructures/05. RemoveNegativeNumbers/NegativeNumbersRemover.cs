// 05. Write a program that removes from given sequence all negative numbers.

namespace _05.RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NegativeNumbersRemover
    {
        static void Main()
        {
            var initialList = new List<int> { 1, 0, -1, 5, 6, 7, -2, 3, -5 };
            var nonNegative = initialList.Where(x => x >= 0);
            Console.WriteLine("Initial list: {0}; Nonnegative only: {1}", 
                string.Join(", ", initialList),
                string.Join(", ", nonNegative));
        }
    }
}
