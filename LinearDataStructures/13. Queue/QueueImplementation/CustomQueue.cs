namespace _13.Queue.QueueImplementation
{
    using System;

    public class CustomQueue<T>
    {
        private CustomLinkedList<T> items;

        public CustomQueue()
        {
            this.items = new CustomLinkedList<T>();
        }

        public void Enqueue(T value)
        {
            this.items.AddFirst(value);
        }

        public T Dequeue()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T last = this.items.Tail.Value;

            this.items.RemoveLast();

            return last;
        }

        public T Peek()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return this.items.Tail.Value;
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public CustomLinkedList<T> Items
        {
            get
            {
                return items;
            }

            set
            {
                this.items = value;
            }
        }
    }
}
