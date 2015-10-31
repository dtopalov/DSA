namespace _11.LinkedList.LinkedListImplementation
{
    using System.Collections;
    using System.Collections.Generic;

    public class CustomLinkedList<T> : ICollection<T>
    {
        private CustomLinkedListNode<T> head;
        private CustomLinkedListNode<T> tail;

        public CustomLinkedListNode<T> Head
        {
            get
            {
                return this.head;
            }
        }

        public CustomLinkedListNode<T> Tail
        {
            get
            {
                return this.tail;
            }
        }

        public void AddFirst(T value)
        {
            CustomLinkedListNode<T> node = new CustomLinkedListNode<T>(value);

            // Save off the head node so we don't lose it
            CustomLinkedListNode<T> temp = this.head;

            // Point head to the new node
            this.head = node;

            // Insert the rest of the list behind head
            this.head.Next = temp;

            if (this.Count == 0)
            {
                // if the list was empty then head and tail should
                // both point to the new node.
                this.tail = this.head;
            }

            this.Count++;
        }

        public void AddLast(T value)
        {
            CustomLinkedListNode<T> node = new CustomLinkedListNode<T>(value);

            if (this.Count == 0)
            {
                this.head = node;
            }
            else
            {
                this.tail.Next = node;
            }
            this.tail = node;
            this.Count++;
        }

        public void Add(T value)
        {
            this.AddLast(value);
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            CustomLinkedListNode<T> current = this.head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            CustomLinkedListNode<T> current = this.head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public int Count
        {
            get;
            private set;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void RemoveFirst()
        {
            if (this.Count != 0)
            {
                this.head = this.head.Next;

                this.Count--;

                if (this.Count == 0)
                {
                    this.tail = null;
                }
            }
        }

        public void RemoveLast()
        {
            if (this.Count != 0)
            {
                if (this.Count == 1)
                {
                    this.head = null;
                    this.tail = null;
                }
                else
                {
                    var currentNode = this.Head;
                    var tempTail = this.tail;
                    this.tail = null;
                    while (currentNode.Next != tempTail)
                    {
                        currentNode = currentNode.Next;
                    }

                    this.tail = currentNode;
                    this.tail.Next = null;
                }

                this.Count--;
            }
        }

        public bool Remove(T item)
        {
            CustomLinkedListNode<T> previous = null;
            CustomLinkedListNode<T> current = this.head;

            // 1: Empty list - do nothing
            // 2: Single node: (previous is null)
            // 3: Many nodes
            //    a: node to remove is the first node
            //    b: node to remove is the middle or last

            while (current != null)
            {
                // Head -> 3 -> 5 -> 7 -> null
                // Head -> 3 ------> 7 -> null
                if (current.Value.Equals(item))
                {
                    // it's a node in the middle or end
                    if (previous != null)
                    {
                        // Case 3b
                        previous.Next = current.Next;

                        // it was the end - so update Tail
                        if (current.Next == null)
                        {
                            this.tail = previous;
                        }

                        this.Count--;
                    }
                    else
                    {
                        // Case 2 or 3a
                        this.RemoveFirst();
                    }
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            CustomLinkedListNode<T> current = this.head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}