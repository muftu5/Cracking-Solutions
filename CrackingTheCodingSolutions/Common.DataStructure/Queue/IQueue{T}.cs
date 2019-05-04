﻿namespace Common.DataStructure.Queue
{
    public interface IQueue<T>
    {
        void Add(T element);
        T Remove();
        T Peek();
        bool IsEmpty();
    }
}
