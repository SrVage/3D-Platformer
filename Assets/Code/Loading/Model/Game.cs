using Code.Abstraction;
using Code.Contollers;
using Code.Loading.States;
using Code.Loading.View;
using Code.Services;
using Code.View;

namespace Code.Loading.Model
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;
        public Game(ICoroutineRunner coroutineRunner, Curtain instantiate, FactoryPrefabs factoryPrefabs,
            LevelList levelList, Controllers controllers)
        {
            StateMachine = new GameStateMachine(instantiate, ServiceLocator.Container, new SceneLoader(coroutineRunner), factoryPrefabs, levelList, controllers);
        }
    }
}