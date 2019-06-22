using Common.DataStructures;

namespace RemoveDups
{
    public class LinkedList<T> : SinglyLinkedList<T>
    {
        public LinkedList<T> RemoveDuplicates()
        {
            foreach (var node in this)
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
    }
}
