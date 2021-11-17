using UnityEngine;

namespace Code.Loading.Abstraction
{
    public interface IInputService:IService
    {
        Vector2 Axis { get; }
        bool Jump { get; }
    }
}