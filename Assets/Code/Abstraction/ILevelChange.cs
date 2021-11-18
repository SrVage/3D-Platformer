namespace Code.Abstraction
{
    public interface ILevelChange:IService, IListenerLevel<int>
    {
        int CurrentLevel { get; }
        void ChangeLevel();
    }
}