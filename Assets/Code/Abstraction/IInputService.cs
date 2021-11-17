using UnityEngine;

namespace Code.Abstraction
{
    public interface IInputService:IService
    {
        Vector2 Axis { get; }
        bool Jump { get; }
    }
}