namespace _01.BinaryPasswords
{
    using System;
    using System.Linq;

    class BinaryPasswords
    {
        static void Main()
        {
            
            Console.WriteLine((long)Math.Pow(2, Console.ReadLine().ToCharArray().Count(x => x == '*')));
        }
    }
}
