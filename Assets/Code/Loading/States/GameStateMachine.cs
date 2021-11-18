using System;
using System.Collections.Generic;
using Code.Abstraction;
using Code.Contollers;
using Code.Loading.Model;
using Code.Loading.View;
using Code.Services;
using Code.View;

namespace Code.Loading.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;
        public GameStateMachine(Curtain curtain, ServiceLocator serviceLocator, SceneLoader sceneLoader,
            FactoryPrefabs factoryPrefabs, LevelList levelList, Controllers controllers)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, curtain, serviceLocator, sceneLoader, factoryPrefabs, levelList, controllers),
                [typeof(LoadLevelState)] = new LoadLevelState(this, curtain, serviceLocator, sceneLoader, levelList),
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