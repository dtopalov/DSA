namespace _01.NestedLoops
{
    using System;

    class NestedLoopsSimulation
    {
        static void Main()
        {
            int size = 3;
            int[] vector = new int[size];

            // Change the size and the last to arguments for different results: 
            // size = 3, from = 1 and to = 3 will generate 1, 1, 1; 1, 1, 2; ... 1, 2, 1; ... 3, 3, 3
            // size = 4, from = 3 and to = 6 will generate 3, 3, 3, 3; ... 3, 3, 3, 4; ... 6, 6, 6, 6 etc.
            GenerateVariations(0, vector, 1, size);
        }

        static void GenerateVariations(int index, int[] vector, int from, int to)
        {
            if (index == to - from + 1)
            {
                Console.WriteLine(string.Join(", ", vector));
            }
            else
            {
                for (int i = from; i <= to; i++)
                {
                    vector[index] = i;
                    GenerateVariations(index + 1, vector, from, to);
                }
            }
        }
    }
}
