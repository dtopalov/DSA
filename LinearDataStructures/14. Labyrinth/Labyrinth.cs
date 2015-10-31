namespace _14.Labyrinth
{
    using System;
    using System.Collections.Generic;

    public class Labyrinth
    {
        public Labyrinth(int size)
        {
            this.Lab = new string[size, size];
            this.Size = size;
            this.startCoordinates = new[] { rand.Next(0, this.Size), rand.Next(0, this.Size) };
            this.GenerateLabyrinth();
            this.SetStart(this.Lab);
        }
        public int Size { get; set; }

        public string[,] Lab { get; set; }

        private static Random rand = new Random();

        private readonly int[] startCoordinates;

        private void GenerateLabyrinth()
        {
            var cellContent = "00X";

            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    this.Lab[i, j] = cellContent[rand.Next(0, 3)].ToString();
                }
            }
        }

        private void SetStart(string[,] lab)
        {
            lab[startCoordinates[0], startCoordinates[1]] = "S";
        }

        public void Print()
        {
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    Console.Write(this.Lab[i, j].PadLeft(4));
                }

                Console.WriteLine();
            }
        }

        public void Fill()
        {
            var currentPath = new Queue<int[]>();
            currentPath.Enqueue(this.startCoordinates);
            var currentCell = this.startCoordinates;
            bool canContinue = true;
            int currentNumber = 1;

            while (canContinue)
            {
                bool canGoUp = currentCell[0] - 1 >= 0 && this.Lab[currentCell[0] - 1, currentCell[1]] == "0";
                bool canGoDown = currentCell[0] + 1 < this.Size && this.Lab[currentCell[0] + 1, currentCell[1]] == "0";
                bool canGoRight = currentCell[1] + 1 < this.Size && this.Lab[currentCell[0], currentCell[1] + 1] == "0";
                bool canGoLeft = currentCell[1] - 1 >= 0 && this.Lab[currentCell[0], currentCell[1] - 1] == "0";
                canContinue = canGoLeft || canGoDown || canGoRight || canGoUp;
                var currentNeighbours = new List<int[]>();

                if (canGoLeft)
                {
                    currentNeighbours.Add(new[] {currentCell[0], currentCell[1] - 1});
                }

                if (canGoRight)
                {
                    currentNeighbours.Add(new[] { currentCell[0], currentCell[1] + 1 });
                }

                if (canGoUp)
                {
                    currentNeighbours.Add(new[] { currentCell[0] - 1, currentCell[1] });
                }

                if (canGoDown)
                {
                    currentNeighbours.Add(new[] { currentCell[0] + 1, currentCell[1] });
                }

                if (currentNeighbours.Count > 0)
                {
                    currentCell = currentNeighbours[0];
                    foreach (var neighbour in currentNeighbours)
                    {
                        if (int.Parse(this.Lab[neighbour[0], neighbour[1]]) == 0)
                        {
                            this.Lab[neighbour[0], neighbour[1]] = currentNumber.ToString();
                            currentPath.Enqueue(neighbour);
                        }
                    }
                    currentPath.Dequeue();
                }

                currentNeighbours.Clear();
                currentNumber++;
            }

            while (currentPath.Count > 0)
            {
                Console.WriteLine(string.Join(", ", currentPath.Dequeue()));
            }
        }
    }
}