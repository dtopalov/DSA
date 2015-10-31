// 8. *The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
// Write a program to find the majorant of given array (if exists).

namespace _08.Majorant
{
    using System;
    using System.Linq;

    public class MajorantFinder
    {
        static void Main()
        {
            // sample data with no majorant, uncomment this and comment the other sample if you want to test it
            // var numbers = new[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            // sample data with majorant
            var numbers = new[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            Console.WriteLine(string.Join(", ", numbers));
            var groupedByOccurence = numbers.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault();

            if (groupedByOccurence != null && groupedByOccurence.Count()> numbers.Count() / 2)
            {
                Console.WriteLine("Majorant --> {0} ({1} occurences)", groupedByOccurence.Key, groupedByOccurence.Count());
                return;
            }

            Console.WriteLine("No majorant in the given sequence.");
        }
    }
}
