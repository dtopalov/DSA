namespace Denominators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Denominators
    {
        static List<int> permutations = new List<int>();

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] digits = new int[n];

            for (int i = 0; i < n; i++)
            {
                digits[i] = int.Parse(Console.ReadLine());
            }

            PermuteRep(digits, 0, n);

            var listOfValDenom = new List<ValDenom>();

            permutations.ForEach(x => listOfValDenom.Add(new ValDenom(x, DenomCount(x))));

            var result = listOfValDenom.OrderBy(x => x.NumberOfDenoms).ThenBy(x => x.Value).First();

            Console.WriteLine(result.Value);
        }

        public class ValDenom
        {
            public ValDenom(int value, int denoms)
            {
                this.Value = value;
                this.NumberOfDenoms = denoms;
            }

            public int Value { get; set; }

            public int NumberOfDenoms { get; set; }

            //public int CompareTo(ValDenom other)
            //{
            //    return this.NumberOfDenoms.CompareTo(other.NumberOfDenoms);
            //}
        }

        static int DenomCount(int number)
        {
            int denominators = 0;

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    denominators++;
                }
            }

            return denominators;
        }

        static void PermuteRep(int[] arr, int start, int n)
        {   
            permutations.Add(int.Parse(string.Join(string.Empty, arr)));

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, n);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = firstElement;
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
