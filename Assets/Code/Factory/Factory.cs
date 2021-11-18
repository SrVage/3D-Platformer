using System.Collections.Generic;
using Code.Abstraction;
using Code.Abstraction.Controllers;
using Code.Contollers;
using Code.Hero;
using Code.Loading.Model;
using Code.Services;
using UnityEngine;

namespace Code.Factory
{
    public class Factory:IFactory
    {
        private readonly FactoryPrefabs _factoryPrefabs;
        private readonly LevelList _list;
        private readonly Controllers _controllers;
        private readonly IInputService _inputService;
        private List<GameObject> _gameObjects;
        private List<IController> _controller;
        private readonly ILevelChange _levelChange;

        public Factory(FactoryPrefabs factoryPrefabs, ServiceLocator serviceLocator, LevelList list,
            Controllers controllers)
        {
            _factoryPrefabs = factoryPrefabs;
            _list = list;
            _controllers = controllers;
            _gameObjects = new List<GameObject>();
            _controller = new List<IController>();
            _inputService = serviceLocator.Single<IInputService>();
            _levelChange = serviceLocator.Single<ILevelChange>();
        }

        public void CreateLevel()
        {
            Debug.LogWarning(_levelChange.CurrentLevel);
            var level = GameObject.Instantiate(_list.LevelConfigs[_levelChange.CurrentLevel%_list.LevelConfigs.Count].LevelPrefab);
            _gameObjects.Add(level);
        }

        public GameObject CreateHero()
        {
            var hero = GameObject.Instantiate(_factoryPrefabs.Hero);
            //_gameObjects.Add(hero);
            var heroController = new HeroMoveController();
            heroController.Init(_inputService, hero.GetComponent<HeroMove>());
            _controllers.AddController(heroController);
            _controller.Add(heroController);
            BindingCamera(hero.transform);
            var heroAnimationController =
                new HeroAnimationController(hero.GetComponent<HeroAnimation>(), heroController);
            _controllers.AddController(heroAnimationController);
            _controller.Add(heroAnimationController);
           // hero.GetComponent<HeroMove>().Init(_inputService);
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

            foreach (var controller in _controller)
            {
                controller.Disposed();
            }
            _gameObjects.Clear();
            _controller.Clear();
        }

        private void BindingCamera(Transform follow)
        {
            var cameraController = new CameraFollowController(follow, Camera.main.transform.parent);
            _controllers.AddController(cameraController);
            _controller.Add(cameraController);
        }
    }
}