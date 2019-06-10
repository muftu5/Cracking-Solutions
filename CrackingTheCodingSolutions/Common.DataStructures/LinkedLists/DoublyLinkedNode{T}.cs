namespace Common.DataStructure.LinkedLists
{
    public class DoublyLinkedNode<T>
    {
        public T Value { get; private set; }

        private DoublyLinkedNode<T> _next;
        private DoublyLinkedNode<T> _prev;

        public DoublyLinkedNode(T value)
        {
            Value = value;
        }

        public DoublyLinkedNode<T> SetNext(DoublyLinkedNode<T> node)
        {
            _next = node;
            return this;
        }

        public DoublyLinkedNode<T> SetPrev(DoublyLinkedNode<T> node)
        {
            _prev = node;
            return this;
        }

        public DoublyLinkedNode<T> GetNext() => _next;
        public DoublyLinkedNode<T> GetPrev() => _prev;
        public bool HasNext() => _next != null;
        public bool HasPrev() => _prev != null;
    }
}
