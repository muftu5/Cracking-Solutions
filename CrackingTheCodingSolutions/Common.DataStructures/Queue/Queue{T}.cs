using System;

namespace Common.DataStructure.Queue
{
    public class Queue<T> : IQueue<T>
    {
        private readonly SinglyLinkedList<T> _linkedList;

        public Queue()
        {
            _linkedList = new SinglyLinkedList<T>();
        }

        public void Add(T element) => _linkedList.AppendHead(element);


        public bool IsEmpty() => _linkedList.Head() == null;


        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            return _linkedList.Tail().Value;
        }

        public T Remove() => _linkedList.RemoveTail();
    }
}
