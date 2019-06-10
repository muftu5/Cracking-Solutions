using System;

namespace Common.DataStructure.LinkedLists
{
    public class DoublyLinkedList<T>
    {
        protected DoublyLinkedNode<T> _tail;
        protected DoublyLinkedNode<T> _head;

        public DoublyLinkedNode<T> Tail => _tail;
        public DoublyLinkedNode<T> Head => _head;

        public void AppendTail(T value)
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

        public T RemoveTail()
        {
            if (_tail == null)
                throw new InvalidOperationException();

            var value = _tail.Value;

            if (!_tail.HasNext())
            {
                _tail = null;
                _head = null;
                return value;
            }

            var next = _tail.GetNext();

            next.SetPrev(null);
            _tail.SetNext(null);

            _tail = next;
            return value;
        }

        public void AppendHead(T value)
        {
            var node = new DoublyLinkedNode<T>(value);

            if (_head == null)
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
