using System;
using System.Collections.Generic;
using Code.Loading.Abstraction;
using Code.Loading.Model;
using Code.Services;
using DefaultNamespace;

namespace Code.Loading.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;
        public GameStateMachine(Curtain curtain, ServiceLocator serviceLocator, SceneLoader sceneLoader,
            FactoryPrefabs factoryPrefabs, LevelList levelList)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, curtain, serviceLocator, sceneLoader, factoryPrefabs, levelList),
                [typeof(LoadLevelState)] = new LoadLevelState(this, curtain, serviceLocator, sceneLoader),
                [typeof(GameLoopState)] = new GameLoopState(this)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState>(string levelName) where TState : class, ILoadState
        {
            TState state = ChangeState<TState>();
            state.Enter(levelName);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => _states[typeof(TState)] as TState;
    }
}