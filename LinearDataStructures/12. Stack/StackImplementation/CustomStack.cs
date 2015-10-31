namespace _12.Stack.StackImplementation
{
    using System;

    public class CustomStack<T>
    {
        private T[] items;

        public CustomStack()
        {
            this.items = new T[4];
        }

        public void Push(T value)
        {
            if (this.Count >= this.items.Length)
            {
                Array.Resize(ref this.items, this.items.Length * 2);
            }

            this.items[this.Count] = value;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            T result = this.items[this.Count - 1];
            this.Count--;

            return result;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return this.items[this.Count - 1];
        }

        public int Count { get; set; }
    }
}
