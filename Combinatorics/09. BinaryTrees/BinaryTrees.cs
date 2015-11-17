namespace BinaryTrees
{
    using System;
    using System.Numerics;

    class BinaryTrees
    {
        static ulong[] memo;
        static void Main()
        {
            var input = Console.ReadLine();
            var groups = new int[26];

            foreach (var ball in input)
            {
                groups[ball - 'A']++;
            }

            int n = input.Length;

            memo = new ulong[n + 1];

            var factorials = new ulong[n + 1];
            factorials[0] = 1;

            for (int i = 0; i < n; i++)
            {
                factorials[i + 1] = factorials[i] * (ulong)(i + 1);
            }

            ulong result = factorials[n];
            foreach (var x in groups)
            {
                result /= factorials[x];
            }

            BigInteger finalResult = (BigInteger)result * Trees(n);

            Console.WriteLine(finalResult);
        }

        static ulong Trees(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (memo[n] > 0)
            {
                return memo[n];
            }

            ulong result = 0;
            for (int i = 0; i < n; i++)
            {
                result += Trees(i) * Trees(n - 1 - i);
            }

            memo[n] = result;
            return result;
        }
    }
}
