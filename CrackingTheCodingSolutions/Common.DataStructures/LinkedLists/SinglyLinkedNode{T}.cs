namespace Common.DataStructure
{
    public class SinglyLinkedNode<T>
    {
        public T Value { get; private set; }
        private SinglyLinkedNode<T> _next;

        public SinglyLinkedNode(T value)
        {
            Value = value;
        }

        public SinglyLinkedNode<T> SetNext(SinglyLinkedNode<T> value)
        {
            _next = value;
            return _next;
        }

        public SinglyLinkedNode<T> GetNext() => _next;
        public bool HasNext() => _next != null;
    }

}
