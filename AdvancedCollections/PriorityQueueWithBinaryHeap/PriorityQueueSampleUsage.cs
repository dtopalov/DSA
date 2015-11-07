namespace PriorityQueueWithBinaryHeap
{
    using System;

    class PriorityQueueSampleUsage
    {
        static void Main()
        {
            BinaryHeap<int> maxPriorityQueue = new BinaryHeap<int>(5);
            maxPriorityQueue.Insert(4);
            maxPriorityQueue.Insert(1);
            maxPriorityQueue.Insert(2);
            maxPriorityQueue.Insert(5);
            maxPriorityQueue.Insert(3);

            Console.WriteLine("Max first (default): ");
            while (maxPriorityQueue.Size > 0)
            {
                Console.WriteLine(maxPriorityQueue.Pop());
            }

            BinaryHeap<int> minPriorityQueue = new BinaryHeap<int>(5, MinIntCompare);

            minPriorityQueue.Insert(4);
            minPriorityQueue.Insert(1);
            minPriorityQueue.Insert(2);
            minPriorityQueue.Insert(5);
            minPriorityQueue.Insert(3);

            Console.WriteLine("Min first (custom comparison passed):");
            while (minPriorityQueue.Size > 0)
            {
                Console.WriteLine(minPriorityQueue.Pop());
            }
        }

        private static int MinIntCompare(int i1, int i2)
        {
            return i1 < i2 ? 1 : i1 > i2 ? -1 : 0;
        }
    }
}
