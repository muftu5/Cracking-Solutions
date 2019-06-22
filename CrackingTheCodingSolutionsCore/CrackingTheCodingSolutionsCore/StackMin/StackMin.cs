using Common.DataStructures;
using System;

namespace StackMin
{
    public class StackMin : Stack<int>, IStack<int>
    {
        private Stack<int> _minElements = new Stack<int>();

        public override void Push(int element)
        {
            if (_minElements.IsEmpty())
                _minElements.Push(element);
            else
                _minElements.Push(Math.Min(_minElements.Peek(), element));

            base.Push(element);
        }

        public override int Pop()
        {
            _minElements.Pop();
            return base.Pop();
        }

        public int Min() => _minElements.Peek();
    }
}
