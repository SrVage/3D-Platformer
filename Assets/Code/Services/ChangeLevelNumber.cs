using Code.Abstraction;
using Code.Loading.Model;
using Code.Loading.States;
using UnityEngine;

namespace Code.Services
{
    public class ChangeLevelNumber:ILevelChange
    {
        private readonly GameStateMachine _stateMachine;
        public int CurrentLevel => _currentLevel.CurentLevel;
        private CurrentLevel _currentLevel;
        private IObserver<int> _observer;

        public ChangeLevelNumber(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _currentLevel = new CurrentLevel();
        }

        public void Init(IObserver<int> observer)
        {
            _observer = observer;
            observer.Subscribe(this);
        }

        public void ChangeValue(int value)
        {
            Debug.Log(value);
        }

        public void ChangeLevel()
        {
            _currentLevel.ChangeLevel();
            _observer.Unsubscribe(this);
            _stateMachine.Enter<LoadLevelState>("MainScene");
            
        }

        public void Finish()
        {
            ChangeLevel();
        }
    }
}