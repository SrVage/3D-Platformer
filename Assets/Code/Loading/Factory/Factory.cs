using System.Collections.Generic;
using Code.Loading.Abstraction;
using Code.Loading.Hero;
using Code.Loading.Model;
using Code.Services;
using DefaultNamespace;
using UnityEngine;

namespace Code.Loading.Factory
{
    public class Factory:IFactory
    {
        private readonly FactoryPrefabs _factoryPrefabs;
        private readonly LevelList _list;
        private readonly IInputService _inputService;
        private List<GameObject> _gameObjects;
        private readonly ILevelChange _levelChange;

        public Factory(FactoryPrefabs factoryPrefabs, ServiceLocator serviceLocator, LevelList list)
        {
            _factoryPrefabs = factoryPrefabs;
            _list = list;
            _gameObjects = new List<GameObject>();
            _inputService = serviceLocator.Single<IInputService>();
            _levelChange = serviceLocator.Single<ILevelChange>();
        }

        public void CreateLevel()
        {
            var level = GameObject.Instantiate(_list.LevelPrefab[_levelChange.CurrentLevel]);
            _gameObjects.Add(level);
        }

        public GameObject CreateHero()
        {
            var hero = GameObject.Instantiate(_factoryPrefabs.Hero);
            _gameObjects.Add(hero);
            hero.GetComponent<HeroMove>().Init(_inputService);
            return hero;
        }

        public void CreateJoystick()
        {
            var joystick = GameObject.Instantiate(_factoryPrefabs.Joystick);
            _gameObjects.Add(joystick);
        }

        public void Clean()
        {
            foreach (var VARIABLE in _gameObjects)
            {
                GameObject.Destroy(VARIABLE);
            }
            _gameObjects.Clear();
        }
    }
}