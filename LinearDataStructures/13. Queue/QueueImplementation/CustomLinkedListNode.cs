namespace _13.Queue.QueueImplementation
{
    public class CustomLinkedListNode<T>
    {
        /// <summary>
        /// Constructs a new node with the specified value.
        /// </summary>
        public CustomLinkedListNode(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// The node value
        /// </summary>
        public T Value { get; internal set; }

        /// <summary>
        /// The next node in the linked list (null if last node)
        /// </summary>
        public CustomLinkedListNode<T> Next { get; internal set; }

        /// <summary>
        /// The previous node in the linked list (null if first node)
        /// </summary>
        public CustomLinkedListNode<T> Previous { get; internal set; }
    }
}