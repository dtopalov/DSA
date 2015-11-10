namespace _12.EightQueens
{
    using System;

    class EightQueens
    {
        static void Main()
        {
            new Position(0, -1, null).WalkThroughTree();
        }
    }
}
