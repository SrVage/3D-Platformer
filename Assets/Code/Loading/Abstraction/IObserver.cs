namespace Code.Loading.Abstraction
{
    public interface IObserver<T>
    {
        void Subscribe(IListener<T> listener);
        void Unsubscribe(IListener<T> listener);

        void Observe();
    }
}