namespace Common.DataStructures.Deque
{
    public interface IDeque<T>
    {
        void PushFront(T value);
        void PushBack(T value);
        T PopFront();
        T PopBack();
        T PeekFront();
        T PeekBack();
        bool IsEmpty();
    }
}
