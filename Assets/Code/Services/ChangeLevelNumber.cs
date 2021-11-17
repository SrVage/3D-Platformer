using Code.Abstraction;
using Code.Loading.Model;
using Code.Loading.States;

namespace Code.Services
{
    public class ChangeLevelNumber:ILevelChange
    {
        private readonly GameStateMachine _stateMachine;
        public int CurrentLevel => _currentLevel.CurentLevel;
        private CurrentLevel _currentLevel;

        public ChangeLevelNumber(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _currentLevel = new CurrentLevel();
        }

        public void Init(IObserver<int> observer)
        {
            observer.Subscribe(this);
        }

        public void ChangeLevel()
        {
            _currentLevel.ChangeLevel();
            _stateMachine.Enter<LoadLevelState>("MainScene");
        }

        public void ChangeValue(int value)
        {
            if (value > 2)
            {
                ChangeLevel();
            }
        }
    }
}