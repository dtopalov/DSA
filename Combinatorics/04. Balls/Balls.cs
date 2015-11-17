namespace _04.Balls
{
    using System;
    using System.Numerics;

    class Balls
    {
        static BigInteger[] memo = new BigInteger[31];

        static void Main()
        {
            memo[0] = 1;
            memo[1] = 1;

            char[] sequence = Console.ReadLine().ToCharArray();
            Array.Sort(sequence);

            int[] colors = new int[6];
            colors[0] = 1;
            int j = 0;

            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i - 1] != sequence[i])
                {
                    j++;
                }
                colors[j]++;
            }

            BigInteger result = Fact(sequence.Length) / 
                (Fact(colors[0]) * Fact(colors[1]) * Fact(colors[2]) 
                * Fact(colors[3]) * Fact(colors[4]) * Fact(colors[5]));

            Console.WriteLine(result);
        }

        private static BigInteger Fact(int n)
        {
            if (n < 2)
            {
                return 1;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            memo[n] = n * Fact(n - 1);
            return n * Fact(n - 1);
        }
    }
}
