namespace _07.PathsInAMatric
{
    using System;
    using System.Collections.Generic;

    class Paths
    {
        private static readonly char[,] lab =
        {
            {' ', ' ', ' ', 'x', ' ', ' ', ' '},
            {'x', 'x', ' ', 'x', ' ', 'x', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', 'x', 'x', 'x', 'x', 'x', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
        };

        private static readonly List<string> path = new List<string>();
        private static readonly List<int[]> allVisited = new List<int[]>();

        private static int[] startingPoint;
        static void Main()
        {
            int startingRow = 0;
            int startingCol = 0;
            startingPoint = new[] { startingRow, startingCol };

            // You can find paths between arbitrary points changing the starting point from the method arguments
            // and the ending point by changing the place of the 'e' in the matrix above
            FindExit(lab, startingRow, startingCol, string.Empty);

            // Problem 9 solved here as well: all empty cells are visited
            Console.WriteLine();
            Console.WriteLine("All cells that can be visited: ");
            Console.WriteLine();
            for (int i = 0; i < lab.GetLength(0); i++)
            {
                for (int j = 0; j < lab.GetLength(1); j++)
                {
                    if (lab[i, j] == 'e')
                    {
                        Console.Write('E');
                        continue;
                    }

                    if (i == startingPoint[0] && j == startingPoint[1])
                    {
                        Console.Write('S');
                        continue;
                    }

                    var visited = false;
                    foreach (var cell in allVisited)
                    {
                        if (cell[0] == i && cell[1] == j)
                        {
                            Console.Write('V');
                            visited = true;
                            break;
                        }
                    }

                    if (!visited)
                    {
                        Console.Write('-');
                    }
                }
                Console.WriteLine();
            }
        }

        private static void FindExit(char[,] lab, int row, int col, string direction)
        {
            if ((col < 0) || (row < 0) || (col >= lab.GetLength(1))
                || (row >= lab.GetLength(0)))
            {
                // We are out of the labyrinth -> can't find a path
                return;
            }

            // Check if we have found the exit
            if (lab[row, col] == 'e')
            {
                Console.WriteLine(string.Join(" -> ", path));
                Console.WriteLine("Found the exit!");
            }

            if (lab[row, col] != ' ')
            {
                // The current cell is not free -> can't find a path
                return;
            }

            // Temporary mark the current cell as visited
            lab[row, col] = 'v';
            if (direction != string.Empty)
            {
                allVisited.Add(new[] { row, col});
                path.Add(direction);
            }
            
            // Invoke recursion to explore all possible directions
            FindExit(lab, row, col - 1, "Left"); // left
            FindExit(lab, row - 1, col, "Up"); // up
            FindExit(lab, row, col + 1, "Right"); // right
            FindExit(lab, row + 1, col, "Down"); // down

            
            // Mark back the current cell as free
            lab[row, col] = ' ';
            if (path.Count > 0)
            {
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
