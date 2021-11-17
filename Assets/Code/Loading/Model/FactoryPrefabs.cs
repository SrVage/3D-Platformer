using UnityEngine;

namespace Code.Loading.Model
{
    [CreateAssetMenu (order = 1, menuName = "Configs/Prefabs")]
    public class FactoryPrefabs:ScriptableObject
    {
        public GameObject Hero;
        public GameObject Joystick;
    }
}