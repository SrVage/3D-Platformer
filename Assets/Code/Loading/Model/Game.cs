using Code.Loading.Abstraction;
using Code.Loading.States;
using Code.Services;
using DefaultNamespace;

namespace Code.Loading.Model
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;
        public Game(ICoroutineRunner coroutineRunner, Curtain instantiate, FactoryPrefabs factoryPrefabs,
            LevelList levelList)
        {
            StateMachine = new GameStateMachine(instantiate, ServiceLocator.Container, new SceneLoader(coroutineRunner), factoryPrefabs, levelList);
        }
    }
}