namespace Code.Abstraction.Controllers
{
    public interface IFixedExecute:IController
    {
        void FixedExecute(float fixedDeltaTime);
    }
}