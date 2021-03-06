﻿using Common.DataStructures;
using System;

namespace Common.DataStructures
{
    public class Stack<T> : IStack<T>
    {
        protected readonly SinglyLinkedList<T> _linkedList;

        public Stack()
        {
            _linkedList = new SinglyLinkedList<T>();
        }

        public virtual void Push(T element) => _linkedList.AppendTail(element);
        public virtual T Pop() => _linkedList.RemoveTail();
        public bool IsEmpty() => _linkedList.Tail == null;

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            return _linkedList.Tail.Value;
        }
    }
}
