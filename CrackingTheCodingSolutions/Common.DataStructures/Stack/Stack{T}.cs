using System;

namespace Common.DataStructure
{
    public class Stack<T> : IStack<T>
    {
        protected readonly SinglyLinkedList<T> _linkedList;

        public Stack()
        {
            _linkedList = new SinglyLinkedList<T>();
        }

        public bool IsEmpty() => _linkedList.Tail() == null;

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            return _linkedList.Tail().Value;
        }

        public T Pop() => _linkedList.RemoveTail();

        public void Push(T element) => _linkedList.AppendTail(element);
    }
}
