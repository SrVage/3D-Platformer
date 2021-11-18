using UnityEngine;

namespace Code.Loading.Model
{
    public class CurrentLevel
    {
        private const string CurrentLevelKey = nameof(CurrentLevelKey);
        public int CurentLevel => _curentLevel;
        private int _curentLevel;

        public CurrentLevel()
        {
            _curentLevel = PlayerPrefs.GetInt(CurrentLevelKey, 0);
        }

        public void ChangeLevel()
        {
            _curentLevel++;
            PlayerPrefs.SetInt(CurrentLevelKey, _curentLevel);
        }
    }
}