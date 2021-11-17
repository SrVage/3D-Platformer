namespace Code.Abstraction
{
    public interface IState:IExitableState
    {
        void Enter();
    }

    public interface ILoadState : IExitableState
    {
        void Enter(string levelName);
    }

    public interface IExitableState
    {
        void Exit();
    }
}