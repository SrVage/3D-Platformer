using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Loading.Model
{
    [CreateAssetMenu(order = 2, menuName = "Configs/Levels")]
    public class LevelList:ScriptableObject
    {
        public List<LevelConfig> LevelConfigs;
        [Serializable]
        public class LevelConfig
        {
            public GameObject LevelPrefab;
            public int MaxScores;
        }
    }
}