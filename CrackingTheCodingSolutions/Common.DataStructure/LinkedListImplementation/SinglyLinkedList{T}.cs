using System;
using System.Collections.Generic;

namespace Common.DataStructure
{
    public class SinglyLinkedList<T>
    {
        private SinglyLinkedNode<T> _tail;
        private SinglyLinkedNode<T> _head;

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

        public SinglyLinkedList<T> RemoveDuplicates()
        {
            foreach (var node in Enumerate(_tail))
            {
                if (!node.HasNext()) break;
           
                foreach (var runner in Enumerate(node.GetNext()))
                {
                    if (runner.Value.Equals(node.Value))
                        if (runner.HasNext())
                            node.SetNext(runner.GetNext());
                        else
                            node.SetNext(null);
                }
            }

            return this;
        }

        private static IEnumerable<SinglyLinkedNode<T>> Enumerate(SinglyLinkedNode<T> tail)
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

        public IEnumerable<SinglyLinkedNode<T>> Enumerate() => Enumerate(_tail);

        public SinglyLinkedNode<T> Head() => _head;
        public SinglyLinkedNode<T> Tail() => _tail;
    }
}
