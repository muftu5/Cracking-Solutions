using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Common.DataStructure
{
    public class SinglyLinkedList<T> : IEnumerable<SinglyLinkedNode<T>>
    {
        protected SinglyLinkedNode<T> _tail;
        protected SinglyLinkedNode<T> _head;

        public int Count { get; private set; }
        public SinglyLinkedNode<T> Head => _head;
        public SinglyLinkedNode<T> Tail => _tail;

        public SinglyLinkedList()
        {
            Count = 0;
        }

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

            Count++;
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

            Count++;
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

            Count--;
            return tail.Value;
        }

        public T RemoveNext(SinglyLinkedNode<T> node)
        {
            var next = default(SinglyLinkedNode<T>);
            if (node.HasNext())
                next = node.GetNext();

            if (next.HasNext())
                node.SetNext(next.GetNext());
            else
                throw new ArgumentException("Next is null");

            Count--;
            return next.Value;
        }   
        
        public IEnumerator<SinglyLinkedNode<T>> GetEnumerator() 
            => Enumerate(_tail).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        protected static IEnumerable<SinglyLinkedNode<T>> Enumerate(SinglyLinkedNode<T> tail)
        {
            if (tail == null)
                yield break;

            SinglyLinkedNode<T> current = tail;
            while (current != null)
            {
                yield return current;
                current = current.GetNext();
            }
        }
    }
}
