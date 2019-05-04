using System.Linq;

namespace Common.DataStructure
{
    public class Stack<T> : IStack<T>
    {
        private readonly SinglyLinkedList<T> _linkedList;

        public Stack()
        {
            _linkedList = new SinglyLinkedList<T>();
        }

        public bool IsEmpty() => !_linkedList.Enumerate().Any();

        public T Peek() => _linkedList.Head();

        public T Pop() => _linkedList

        public void Push(T element) => _linkedList.Append(element);
    }
}
