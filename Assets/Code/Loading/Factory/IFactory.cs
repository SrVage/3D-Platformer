using Code.Loading.Abstraction;
using UnityEngine;

namespace Code.Loading.Factory
{
    public interface IFactory:IService
    {
        void CreateLevel();
        GameObject CreateHero();
        void CreateJoystick();
        void Clean();
    }
}