using UnityEditor;
using UnityEngine;

namespace Code.Editor
{
    public class Clear
    {
        [MenuItem("Tools/ClearPrefs")]
        public static void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}