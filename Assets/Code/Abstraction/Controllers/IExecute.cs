namespace Code.Abstraction.Controllers
{
    public interface IExecute:IController
    {
        void Execute(float deltaTime);
    }
}