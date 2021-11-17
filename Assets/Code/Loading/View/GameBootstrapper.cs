using System;
using Code.Loading.Abstraction;
using Code.Loading.Model;
using Code.Loading.States;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameBootstrapper:MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        [SerializeField] private Curtain _curtainPrefab;
        [SerializeField] private FactoryPrefabs _factoryPrefabs;
        [SerializeField] private LevelList _levelList;

        private void Awake()
        {
            _game = new Game(this, Instantiate(_curtainPrefab), _factoryPrefabs, _levelList);
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}