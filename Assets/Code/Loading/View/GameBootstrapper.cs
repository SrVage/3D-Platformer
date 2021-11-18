using System;
using Code.Abstraction;
using Code.Contollers;
using Code.Loading.Model;
using Code.Loading.States;
using UnityEngine;

namespace Code.Loading.View
{
    public class GameBootstrapper:MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        [SerializeField] private Curtain _curtainPrefab;
        [SerializeField] private FactoryPrefabs _factoryPrefabs;
        [SerializeField] private LevelList _levelList;
        private Controllers _controllers;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            Time.fixedDeltaTime = 1 / 60f;
            _controllers = new Controllers();
            _game = new Game(this, Instantiate(_curtainPrefab), _factoryPrefabs, _levelList, _controllers);
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            _controllers.Execute(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _controllers.LateExecute(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _controllers.FixedExecute(Time.fixedDeltaTime);
        }
    }
}