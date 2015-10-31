// 04. Write a method that finds the longest subsequence of equal numbers
// in given List and returns the result as new List<int>.

namespace _04.LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestSubsequence
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
            FindMaxSequence(numbers);
            List<int> secondSetOfNumbers = new List<int> { 1, 1, 1, 2, 3, 4, 3, 3, 2, 2, 2, 2 };
            FindMaxSequence(secondSetOfNumbers);
            List<int> thirdSetOfNumbers = new List<int> { 1, 1, 1, 2, 3, 4, 4, 4, 4, 4, 4, 3, 3, 2, 2, 2, 2 };
            FindMaxSequence(thirdSetOfNumbers);
        }

        private static void FindMaxSequence(List<int> numbers)
        {
            int currentSequence = 1;
            int maxSequence = 1;
            int maxSequenceStartIndex = 0;

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    currentSequence++;
                    if (i == numbers.Count - 1 && currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                        maxSequenceStartIndex = i - maxSequence + 1;
                    }
                }
                else
                {
                    if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                        maxSequenceStartIndex = i - maxSequence;
                    }
                    currentSequence = 1;
                }
            }

            List<int> longestSequence = new List<int>();

            for (int i = 0; i < maxSequence; i++)
            {
                longestSequence.Add(numbers[maxSequenceStartIndex]);
            }

            Console.WriteLine(
                "The longest sequence of equal elements in [{0}] consists of {1} elements - [{2}].",
                string.Join(", ", numbers),
                maxSequence,
                string.Join(", ", longestSequence));
        }
    }
}
