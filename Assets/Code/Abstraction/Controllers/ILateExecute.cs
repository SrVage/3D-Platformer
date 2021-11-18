namespace Code.Abstraction.Controllers
{
    public interface ILateExecute:IController
    {
        void LateExecute(float deltaTime);
    }
}