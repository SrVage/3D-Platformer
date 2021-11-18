using System;

namespace Code.Abstraction.Controllers
{
    public interface IController
    {
        event Action<IController> Dispose;
        void Disposed();
    }
}