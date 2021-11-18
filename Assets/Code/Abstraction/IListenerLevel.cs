namespace Code.Abstraction
{
    public interface IListenerLevel<T>:IListener<T>
    {
        void Finish();
    }
}