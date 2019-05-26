using System;
using System.Collections.Generic;

namespace Common.DataStructure
{
    public class SinglyLinkedList<T>
    {
        protected SinglyLinkedNode<T> _tail;
        protected SinglyLinkedNode<T> _head;

        public void AppendHead(T value)
        {
            var node = new SinglyLinkedNode<T>(value);

            if (_tail == null)
            {
                _tail = node;
                _head = _tail;
            }
            else
            {
                _head.SetNext(node);
                _head = node;
            }
        }

        public void AppendTail(T value)
        {
            var node = new SinglyLinkedNode<T>(value);

            if (_tail == null)
            {
                _tail = node;
                _head = _tail;
            }
            else
            {
                node.SetNext(_tail);
                _tail = node;
            }
        }

        public T RemoveTail()
        {
            if (_tail == null)
                throw new InvalidOperationException();

            var tail = _tail;

            if (tail.HasNext())
            {
                _tail = _tail.GetNext();
            }
            else
            {
                _head = null;
                _tail = null;
            }

            return tail.Value;
        }

        public SinglyLinkedNode<T> Head() => _head;
        public SinglyLinkedNode<T> Tail() => _tail;

        public IEnumerable<SinglyLinkedNode<T>> Enumerate() => Enumerate(_tail);

        protected static IEnumerable<SinglyLinkedNode<T>> Enumerate(SinglyLinkedNode<T> tail)
        {
            if (tail == null)
                yield return default(SinglyLinkedNode<T>);

            SinglyLinkedNode<T> current = tail;
            while (current != null)
            {
                yield return current;
                current = current.GetNext();
            }
        }
    }
}
