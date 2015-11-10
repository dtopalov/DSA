namespace _03.CombinationsNoDuplicates
{
    using System;

    class CombinationsNoDuplicates
    {
        static void Main()
        {
            int n = 5;
            int k = 3;
            int[] elements = new int[n];
            int[] combinations = new int[k];

            for (int i = 0; i < n; i++)
            {
                elements[i] = i + 1;
            }

            GenerateCombinationsWithNoDuplicates(0, n, k, elements, combinations);
        }

        private static void GenerateCombinationsWithNoDuplicates(int index, int n, int k, int[] elements, int[] result)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(", ", result));
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    result[index] = elements[i];
                    if (index > 0 && result[index] <= result[index - 1])
                    {
                        continue;
                    }
                    GenerateCombinationsWithNoDuplicates(index + 1, n, k, elements, result);
                }
            }
        }
    }
}
