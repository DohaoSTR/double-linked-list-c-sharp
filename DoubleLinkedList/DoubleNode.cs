namespace DoubleLinkedList
{
    public class DoubleNode<T>
    {
        public DoubleNode(T value)
        {
            Value = value;
        }

        public DoubleNode<T> Next { get; set; }

        public DoubleNode<T> Previous { get; set; }

        public T Value { get; set; }
    }
}