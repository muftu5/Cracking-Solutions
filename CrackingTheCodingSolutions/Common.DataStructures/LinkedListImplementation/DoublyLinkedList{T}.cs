using System;

namespace Common.DataStructure.LinkedListImplementation
{
    public class DoublyLinkedList<T>
    {
        protected DoublyLinkedNode<T> _tail;
        protected DoublyLinkedNode<T> _head;

        public void Append(T value)
        {
            var node = new DoublyLinkedNode<T>(value);

            if (_tail == null)
            {
                _tail = node;
                _head = _tail;
            }
            else
            {
                _head.SetNext(node);
                node.SetPrev(_head);
                _head = node;
            }
        }

        public DoublyLinkedNode<T> Head() => _head;

        public T RemoveHead()
        {
            if (_head == null)
                throw new InvalidOperationException();

            var head = _head;
            var prev = _head.GetPrev();

            if (_head.HasPrev())
            {
                prev.SetNext(null);
                _head = prev;
            }
            else
            {
                _head = null;
                _tail = null;
            }

            return head.Value;
        }
    }
}
