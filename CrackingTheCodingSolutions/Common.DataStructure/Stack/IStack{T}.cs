namespace Common.DataStructure
{
    public interface IStack<T>
    {
        bool IsEmpty();
        void Push(T element);
        T Pop();
        T Peek();
    }
}
