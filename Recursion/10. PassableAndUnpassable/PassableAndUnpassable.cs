using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PassableAndUnpassable
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
            Console.WriteLine("Filled labyrinth:\nPassable cells filled with numbers, unpassable - with 'u' or 'X'\n");
            lab.Print();
        }
    }
}
