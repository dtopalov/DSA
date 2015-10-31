// 7. Write a program that finds in given array of integers 
// (all belonging to the range [0..1000]) how many times each of them occurs.

namespace _07.OccurenceCount
{
    using System;
    using System.Linq;

    public class NumberOccurenceCounter
    {
        static void Main()
        {
            var numbers = new[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            var groupedByOccurence = numbers.GroupBy(x => x).OrderBy(x => x.Key);

            foreach (var group in groupedByOccurence)
            {
                Console.WriteLine("{0} --> {1} times", group.Key, group.Count());
            }
        }
    }
}
