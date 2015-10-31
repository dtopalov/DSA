namespace _14.Labyrinth
{
    class LabyrinthStart
    {
        static void Main()
        {
            var lab = new Labyrinth(6);

            lab.Print();

            lab.Fill();

            lab.Print();
        }
    }
}
