namespace Code.Loading.Abstraction
{
    public interface IListener<T>
    {
        void Init(IObserver<T> observer);
        void ChangeValue(T value);
    }
}