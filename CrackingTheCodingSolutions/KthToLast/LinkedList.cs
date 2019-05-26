using Common.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveDups
{
    public class LinkedList<T> : SinglyLinkedList<T>
    {
        public T GetKthLast(int k)
        {
            var leading = Enumerate().Skip(k);

            if (!leading.Any())
                throw new ArgumentException($"{k} is not a valid k since list contails less elements");

            var trailing = Enumerate();

            foreach (var node in leading)
            {
                if (!node.HasNext())
                    return trailing.First().Value;
                else trailing = trailing.Skip(1);
            }

            return default(T);
        }
    }
}
