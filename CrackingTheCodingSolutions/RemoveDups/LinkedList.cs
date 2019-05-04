using Common.DataStructure;
using System.Collections.Generic;

namespace RemoveDups
{
    public class LinkedList<T> : SinglyLinkedList<T>
    {
        public LinkedList<T> RemoveDuplicates()
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

        public IEnumerable<SinglyLinkedNode<T>> Enumerate() => Enumerate(_tail);
    }
}
