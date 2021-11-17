using Code.Abstraction;
using Code.Factory;
using Code.Loading.Model;
using Code.Services;
using Code.View;
using UnityEngine;

namespace Code.Loading.States
{
    public class BootstrapState:IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly Curtain _instantiate;
        private readonly ServiceLocator _serviceLocator;
        private readonly SceneLoader _sceneLoader;
        private readonly FactoryPrefabs _factoryPrefabs;
        private readonly LevelList _levelList;

        public BootstrapState(GameStateMachine gameStateMachine, Curtain instantiate, ServiceLocator serviceLocator,
            SceneLoader sceneLoader, FactoryPrefabs factoryPrefabs, LevelList levelList)
        {
            _gameStateMachine = gameStateMachine;
            _instantiate = instantiate;
            _serviceLocator = serviceLocator;
            _sceneLoader = sceneLoader;
            _factoryPrefabs = factoryPrefabs;
            _levelList = levelList;
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.LoadScene("LoadScene", EnterLoadLevel);
        }

        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            if (Application.platform == RuntimePlatform.Android)
                _serviceLocator.RegisterService<IInputService>(new AndroidInputService());
            else
                _serviceLocator.RegisterService<IInputService>(new WindowsInputService());
            _serviceLocator.RegisterService<ILevelChange>(new ChangeLevelNumber(_gameStateMachine));
            _serviceLocator.RegisterService<IFactory>(new Factory.Factory(_factoryPrefabs, _serviceLocator, _levelList));
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadLevelState>("MainScene");
        }
    }
}