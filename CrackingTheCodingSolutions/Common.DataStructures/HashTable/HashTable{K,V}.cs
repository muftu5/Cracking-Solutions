using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.DataStructure.HashTable
{
    public class HashTable<K, V> : IHashTable<K, V>
    {
        private const int INITIAL_SIZE = 2;
        private const int SIZE_EXPANSION_MILTIPLIER = 2;

        private SinglyLinkedList<KeyValueBlock>[] _array;
        private int _count = 0;

        public HashTable()
        {
            _array = new SinglyLinkedList<KeyValueBlock>[INITIAL_SIZE];
        }

        public void Add(K key, V value)
        {
            if (_count > _array.Length)
                Expand();

            AddNode(_array, new KeyValueBlock(key, value));
            _count++;
        }

        public bool HasKey(K key, out V value)
        {
            var divider = GetDivider(_array);
            var index = Math.Abs(key.GetHashCode() % divider);

            var node = _array.ElementAtOrDefault(index)
                ?.FirstOrDefault(x => x.Value.Key.Equals(key));

            var isNodeNull = node == null;
            value = isNodeNull ? default(V) : node.Value.Value;
            return !isNodeNull;
        }

        public V Remove(K key)
        {
            var divider = GetDivider(_array);
            var index = Math.Abs(key.GetHashCode() % divider);
            var linkedList = _array.ElementAtOrDefault(index);

            if (linkedList == null)
                throw new ArgumentException("Key not found");

            if (linkedList.Count == 1 && linkedList.First().Value.Key.Equals(key))
            {
                var value = linkedList.RemoveTail().Value;

                _count--;
                return value;
            }

            var prevNode = linkedList.First();
            foreach (var node in linkedList)
            {
                if (node.Value.Key.Equals(key))
                {
                    var value = linkedList.RemoveNext(prevNode).Value;

                    _count--;
                    return value;
                }

                prevNode = node;
            }

            throw new ArgumentException("Key not found");
        }

        private void Expand()
        {
            var newSize = _count * SIZE_EXPANSION_MILTIPLIER;
            var newArray = new SinglyLinkedList<KeyValueBlock>[newSize];

            var nodeValues = _array
                .Where(x => x != null)
                .SelectMany(x => x)
                .Select(x => x.Value).ToList();

            foreach (var block in nodeValues)
                AddNode(newArray, block);

            _array = newArray;
        }

        private void AddNode(
            SinglyLinkedList<KeyValueBlock>[] array,
            KeyValueBlock block)
        {
            var binIndex = Math.Abs(block.GetHashCode() % GetDivider(array));

            if (array.ElementAtOrDefault(binIndex) == null)
                array[binIndex] = new SinglyLinkedList<KeyValueBlock>();

            if (array[binIndex].Any(x => x.Value.Equals(block)))
                throw new InvalidOperationException("Key-Value pair already added.");

            array[binIndex].AppendTail(block);
        }

        private int GetDivider(SinglyLinkedList<KeyValueBlock>[] array)
            => array.Length > 0 ? array.Length : 1;

        protected class KeyValueBlock
        {
            public K Key { get; private set; }
            public V Value { get; private set; }

            public KeyValueBlock(K key, V value)
            {
                Key = key;
                Value = value;
            }

            public override bool Equals(object obj)
            {
                if ((obj == null) || !GetType().Equals(obj.GetType()))
                {
                    return false;
                }
                else
                {
                    var block = (KeyValueBlock)obj;
                    return Value.Equals(block.Value) && Key.Equals(block.Key);
                }
            }
    
            public override int GetHashCode() => Key.GetHashCode();
        }
    }
}
