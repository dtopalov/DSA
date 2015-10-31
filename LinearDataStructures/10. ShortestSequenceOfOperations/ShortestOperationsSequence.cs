// 10. We are given numbers N and M and the following operations:

// N = N+1
// N = N+2
// N = N*2

// Write a program that finds the shortest sequence of operations from the list above that 
// starts from N and finishes in M.

// Hint: use a queue.
// Example: N = 5, M = 16
// Sequence: 5 → 7 → 8 → 16

namespace _10.ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;

    public class ShortestOperationsSequence
    {
        static void Main()
        {
            PrintShortestSequence(5, 16);
        }

        private static void PrintShortestSequence(int start, int target)
        {
            if (start < 0 || start >= target)
            {
                Console.WriteLine("Start should be >= 0 and smaller than the target!");
                return;
            }

            var sequence = new Queue<int>();
            sequence.Enqueue(start);

            if (start + 1 == target)
            {
                sequence.Enqueue(start + 1);
                Console.WriteLine(string.Join(" --> ", sequence));
                return;
            }

            if (start + 2 == target)
            {
                sequence.Enqueue(start + 2);
                Console.WriteLine(string.Join(" --> ", sequence));
                return;
            }

            if (start + 2 > start * 2)
            {
                start += 2;
                sequence.Enqueue(start);
            }

            if (start * 2 > target)
            {
                while (start + 2 <= target)
                {
                    sequence.Enqueue(start += 2);
                }

                if (start != target)
                {
                    sequence.Enqueue(start += 1);
                }

                Console.WriteLine(string.Join(" --> ", sequence));
                return;
            }

            while (start * 2 < target / 2)
            {
                sequence.Enqueue(start *= 2);
            }

            while (start + 2 <= target / 2)
            {
                sequence.Enqueue(start += 2);
            }

            while (start + 1 <= target / 2)
            {
                sequence.Enqueue(start += 1);
            }

            sequence.Enqueue(start *= 2);

            if (start != target)
            {
                sequence.Enqueue(start += 1);
            }

            Console.WriteLine(string.Join(" --> ", sequence));
        }
    }
}
