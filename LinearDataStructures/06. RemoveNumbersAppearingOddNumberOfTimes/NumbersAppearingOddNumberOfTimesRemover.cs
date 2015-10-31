// 6. Write a program that removes from given sequence all numbers that occur odd number of times.

namespace _06.RemoveNumbersAppearingOddNumberOfTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumbersAppearingOddNumberOfTimesRemover
    {
        static void Main()
        {
            var numbers = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            var filteredNumbersGroups = numbers.GroupBy(x => x).Where(x => x.Count() % 2 == 0);

            var filteredNumbers = new List<int>();

            foreach (var group in filteredNumbersGroups)
            {
                filteredNumbers.AddRange(group);
            }

            Console.WriteLine(
                "Initial sequence: {0}; Numbers occuring even number of times: {1}",
                string.Join(", ", numbers),
                string.Join(", ", filteredNumbers));
        }
    }
}
