using Code.Abstraction;
using Code.Factory;
using Code.InteractableObject.View;
using Code.Loading.Model;
using Code.Loading.View;
using Code.Services;
using Code.View;
using UnityEngine;

namespace Code.Loading.States
{
    public class LoadLevelState:ILoadState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly Curtain _curtain;
        private readonly ServiceLocator _serviceLocator;
        private readonly SceneLoader _sceneLoader;
        private readonly LevelList _levelList;
        private IFactory _factory;

        public LoadLevelState(GameStateMachine gameStateMachine, Curtain curtain, ServiceLocator serviceLocator,
            SceneLoader sceneLoader, LevelList levelList)
        {
            _gameStateMachine = gameStateMachine;
            _curtain = curtain;
            _serviceLocator = serviceLocator;
            _sceneLoader = sceneLoader;
            _levelList = levelList;
            _factory = _serviceLocator.Single<IFactory>();
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        public void Enter(string levelName)
        {
            _factory.Clean();
            _curtain.Show();
            _sceneLoader.LoadScene(levelName, OnLoaded);
        }

        private void OnLoaded()
        {
            InitializeWorld();
        }

        private void InitializeWorld()
        {
            CreateInFactory();
            CreateScores();
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void CreateScores()
        {
            var scores = new Scores<int>(_levelList.LevelConfigs[_serviceLocator.Single<ILevelChange>().CurrentLevel%_levelList.LevelConfigs.Count].MaxScores);
            InitCoin(scores);
            Object.FindObjectOfType<ScoresView>().Init(scores);
            _serviceLocator.Single<ILevelChange>().Init(scores);
        }

        private void CreateInFactory()
        {
            _factory.CreateLevel();
            _factory.CreateJoystick();
            _factory.CreateHero();
        }

        private void InitCoin(Scores<int> scores)
        {
            foreach (var coin in Object.FindObjectsOfType<Coin>())
            {
                coin.Init(scores.AddScore);
            }
        }
    }
}