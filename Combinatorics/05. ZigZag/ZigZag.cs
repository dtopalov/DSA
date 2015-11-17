namespace _05.ZigZag
{
    using System;
    using System.Linq;

    class ZigZag
    {
        static int result;

        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            if (input[1] == 1)
            {
                Console.WriteLine(input[0]);
                return;
            }

            int n = input[0];
            int k = input[1];
            bool[] used = new bool[n];

            GetBigger(0, -1, n, k, used);

            Console.WriteLine(result);
        }

        private static void GetBigger(int index, int current, int n, int k, bool[] used)
        {
            if (index == k)
            {
                result++;
                return;
            }

            if (current == n - 1)
            {
                return;
            }

            for (int i = current + 1; i < n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    GetSmaller(index + 1, i, n, k, used);
                    used[i] = false;
                }
            }
        }

        private static void GetSmaller(int index, int current, int n, int k, bool[] used)
        {
            if (index == k)
            {
                result++;
                return;
            }

            if (current == 0)
            {
                return;
            }

            for (int i = current - 1; i >= 0; i--)
            {
                if (!used[i])
                {
                    used[i] = true;
                    GetBigger(index + 1, i, n, k, used);
                    used[i] = false;
                }
            }
        }
    }
}
