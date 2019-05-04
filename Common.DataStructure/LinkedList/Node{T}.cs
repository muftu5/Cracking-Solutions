namespace Common.DataStructure
{
    public class Node<T>
    {
        public T Value { get; private set; }
        private Node<T> _next;

        public Node(T value)
        {
            Value = value;
        }

        public Node<T> SetNext(Node<T> value)
        {
            _next = value;
            return _next;
        }

        public Node<T> GetNext() => _next;

        public bool HasNext() => _next != null;
    }
}
