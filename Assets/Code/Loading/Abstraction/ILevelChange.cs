namespace Code.Loading.Abstraction
{
    public interface ILevelChange:IService, IListener<int>
    {
        int CurrentLevel { get; }
        void ChangeLevel();
    }
}