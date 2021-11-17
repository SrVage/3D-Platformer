namespace Code.Abstraction
{
    public interface ILevelChange:IService, IListener<int>
    {
        int CurrentLevel { get; }
        void ChangeLevel();
    }
}