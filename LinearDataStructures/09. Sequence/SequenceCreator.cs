// 9. We are given the following sequence:
  
// S1 = N;
// S2 = S1 + 1;
// S3 = 2* S1 + 1;
// S4 = S1 + 2;
// S5 = S2 + 1;
// S6 = 2* S2 + 1;
// S7 = S2 + 2;
// ...
// Using the Queue<T> class write a program to print its first 50 members for given N.
// Example: N= 2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

namespace _09.Sequence
{
    using System;
    using System.Collections.Generic;

    public class SequenceCreator
    {
        public static void Main()
        {
            PrintSequence(2, 50);
        }

        private static void PrintSequence(int start, int targetSequenceLength)
        {
            Queue<int> container = new Queue<int>();
            container.Enqueue(start);
            var result = new Queue<int>();

            while (result.Count < targetSequenceLength)
            {
                int currentBase = container.Dequeue();
                result.Enqueue(currentBase);
                container.Enqueue(currentBase + 1);
                container.Enqueue(2 * currentBase + 1);
                container.Enqueue(currentBase + 2);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
