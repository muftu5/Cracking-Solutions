using Common.DataStructure;
using Common.DataStructure.LinkedListImplementation;
using System;

namespace StackMin
{
    public class StackMin: IStack<int>
    {
        private int _minElement = int.MaxValue;

        private readonly DoublyLinkedList<int> _linkedList;

        public StackMin()
        {
            _linkedList = new DoublyLinkedList<int>();
        }

        public bool IsEmpty() => _linkedList.Head() == null;

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            return _linkedList.Head().Value;
        }

        public int Pop() => _linkedList.RemoveHead();

        public void Push(int element)
        {
            if (_minElement == int.MaxValue)
                _minElement = element;
            else
                _minElement = Math.Min(element, _minElement);
        }

        public int MinElement() => _minElement;
    }
}
