using Common.DataStructure.LinkedLists;
using System;

namespace Common.DataStructure.Deque
{
    public class Deque<T> : IDeque<T>
    {
        private readonly DoublyLinkedList<T> _list = new DoublyLinkedList<T>();

        public T PeekBack()
        {
            if (_list.Tail == null)
                throw new InvalidOperationException();

            return _list.Tail.Value;
        }

        public T PeekFront()
        {
            if (_list.Head == null)
                throw new InvalidOperationException();

            return _list.Head.Value;
        }

        public T PopBack() => _list.RemoveTail();
        public T PopFront() => _list.RemoveHead();
        public void PushBack(T value) => _list.AppendTail(value);
        public void PushFront(T value) => _list.AppendHead(value);
        public bool IsEmpty() => _list.Tail == null;
    }
}
