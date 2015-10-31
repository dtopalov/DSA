namespace _14.Labyrinth
{
    using System;

    class LabyrinthStart
    {
        static void Main()
        {
            var lab = new Labyrinth(10);

            Console.WriteLine("Empty labyrinth:\n");
            lab.Print();
            Console.WriteLine();
            lab.Fill();
            Console.WriteLine("Filled labyrinth:\n");
            lab.Print();
        }
    }
}
