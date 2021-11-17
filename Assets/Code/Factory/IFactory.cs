using Code.Abstraction;
using UnityEngine;

namespace Code.Factory
{
    public interface IFactory:IService
    {
        void CreateLevel();
        GameObject CreateHero();
        void CreateJoystick();
        void Clean();
    }
}