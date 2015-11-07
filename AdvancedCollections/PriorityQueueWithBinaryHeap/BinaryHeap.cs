namespace PriorityQueueWithBinaryHeap
{
    using System;
    using System.Collections.Generic;

    public class BinaryHeap<T>
    {
        private T[] data;

        private int size;

        private Comparison<T> comparison;

        public BinaryHeap()
        {
            this.Constructor(4, null);
        }

        public BinaryHeap(Comparison<T> comparison)
        {
            this.Constructor(4, comparison);
        }

        public BinaryHeap(int capacity)
        {
            this.Constructor(capacity, null);
        }

        public BinaryHeap(int capacity, Comparison<T> comparison)
        {
            this.Constructor(capacity, comparison);
        }

        private void Constructor(int capacity, Comparison<T> customComparison)
        {
            this.data = new T[capacity];
            this.comparison = customComparison;
            if (this.comparison == null)
            {
                this.comparison = Comparer<T>.Default.Compare;
            }
        }

        public int Size => this.size;

        /// <summary>
        /// Add an item to the heap.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        public void Insert(T item)
        {
            if (this.size == this.data.Length) this.Resize();
            this.data[this.size] = item;
            this.HeapifyUp(this.size);
            this.size++;
        }

        /// <summary>
        /// Get the item of the root.
        /// </summary>
        /// <returns>The root item.</returns>
        public T Peak()
        {
            return this.data[0];
        }

        /// <summary>
        /// Extract the item of the root.
        /// </summary>
        /// <returns>The root item.</returns>
        public T Pop()
        {
            T item = this.data[0];
            this.size--;
            this.data[0] = this.data[this.size];
            this.HeapifyDown(0);
            return item;
        }

        private void Resize()
        {
            T[] resizedData = new T[this.data.Length * 2];
            Array.Copy(this.data, 0, resizedData, 0, this.data.Length);
            this.data = resizedData;
        }

        private void HeapifyUp(int childIdx)
        {
            if (childIdx > 0)
            {
                int parentIdx = (childIdx - 1) / 2;
                if (this.comparison.Invoke(this.data[childIdx], this.data[parentIdx]) > 0)
                {
                    // swap parent and child
                    T t = this.data[parentIdx];
                    this.data[parentIdx] = this.data[childIdx];
                    this.data[childIdx] = t;
                    this.HeapifyUp(parentIdx);
                }
            }
        }

        private void HeapifyDown(int parentIdx)
        {
            int leftChildIdx = 2 * parentIdx + 1;
            int rightChildIdx = leftChildIdx + 1;
            int largestChildIdx = parentIdx;
            if (leftChildIdx < this.size && this.comparison.Invoke(this.data[leftChildIdx], this.data[largestChildIdx]) > 0)
            {
                largestChildIdx = leftChildIdx;
            }
            if (rightChildIdx < this.size && this.comparison.Invoke(this.data[rightChildIdx], this.data[largestChildIdx]) > 0)
            {
                largestChildIdx = rightChildIdx;
            }
            if (largestChildIdx != parentIdx)
            {
                T t = this.data[parentIdx];
                this.data[parentIdx] = this.data[largestChildIdx];
                this.data[largestChildIdx] = t;
                this.HeapifyDown(largestChildIdx);
            }
        }
    }
}
