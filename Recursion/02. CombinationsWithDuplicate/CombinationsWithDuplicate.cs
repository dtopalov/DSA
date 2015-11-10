namespace CombinationsWithDuplicate
{
    using System;

    class CombinationsWithDuplicate
    {
        static void Main()
        {
            int n = 3;
            int k = 2;
            int[] elements = new int[n];
            int[] combinations = new int[k];

            for (int i = 0; i < n; i++)
            {
                elements[i] = i + 1;
            }
            
            GenerateCombinationsWithDuplicates(0, n, k, elements, combinations);
        }

        private static void GenerateCombinationsWithDuplicates(int index, int n, int k, int[] elements, int[] result)
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
                    if (index > 0 && result[index] < result[index - 1])
                    {
                        continue;
                    }
                    GenerateCombinationsWithDuplicates(index + 1, n, k, elements, result);
                }
            }
        }
    }
}
