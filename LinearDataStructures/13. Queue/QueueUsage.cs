// 13. Implement the ADT queue as dynamic linked list.

// Use generics(LinkedQueue<T>) to allow storing different data types in the queue.

namespace _13.Queue
{
    using System;

    using _13.Queue.QueueImplementation;

    public class QueueUsage
    {
        static void Main()
        {
            var testQ = new CustomQueue<int>();
            testQ.Enqueue(1);
            testQ.Enqueue(2);
            testQ.Enqueue(3);

            while (testQ.Count > 0)
            {
                Console.WriteLine(testQ.Dequeue());
            }
        }
    }
}
