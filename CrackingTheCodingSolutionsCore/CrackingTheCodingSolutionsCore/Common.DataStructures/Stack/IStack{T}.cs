namespace Common.DataStructures
{
    public interface IStack<T>
    {
        bool IsEmpty();
        void Push(T element);
        T Pop();
        T Peek();
    }
}
