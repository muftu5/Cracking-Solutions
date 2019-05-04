using System.Collections.Generic;

namespace Common.DataStructure
{
    public class SinglyLinkedList<T> 
    {
        private Node<T> _tail { get; set; }
        private Node<T> _head { get; set; }

        public void Append(T value)
        {
            var node = new Node<T>(value);

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

        private static IEnumerable<Node<T>> Enumerate(Node<T> tail)
        {
            if (tail == null)
                yield return default(Node<T>);

            Node<T> current = tail;
            while (current != null)
            {
                yield return current;
                current = current.GetNext();
            }
        }

        public IEnumerable<Node<T>> Enumerate() => Enumerate(_tail);

        public T Head() => _head.Value;
    }
}
