namespace Common.DataStructure.HashTable
{
    public interface IHashTable<K, V>
    {
        void Add(K key, V value);
        bool HasKey(K key, out V value);
        V Remove(K key);
    }
}
