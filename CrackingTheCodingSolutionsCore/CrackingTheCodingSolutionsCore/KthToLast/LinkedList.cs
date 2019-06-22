using Common.DataStructures;
using System;
using System.Linq;

namespace KthToLast
{
    public class LinkedList<T> : SinglyLinkedList<T>
    {
        public T GetKthLast(int k)
        {
            var leading = this.Skip(k);

            if (!leading.Any())
                throw new ArgumentException($"{k} is not a valid k since list contails less elements");

            var trailing = this.AsEnumerable();
            var result = default(T);

            foreach (var node in leading)
            {
                if (!node.HasNext())
                {
                    result = trailing.First().Value;
                    break;
                }
                else trailing = trailing.Skip(1);
            }

            return result;
        }
    }
}
