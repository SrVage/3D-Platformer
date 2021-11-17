using System;
using System.Collections;
using Code.Abstraction;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Loading.Model
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void LoadScene(string sceneName, Action onComplete = null) => 
            _coroutineRunner.StartCoroutine(AsyncLoad(sceneName, onComplete));

        private IEnumerator AsyncLoad(string sceneName, Action onComplete = null)
        {
            if (sceneName == SceneManager.GetActiveScene().name)
            {
                onComplete?.Invoke();
                yield break;
            }
            AsyncOperation asyncHandler = SceneManager.LoadSceneAsync(sceneName);
            while (!asyncHandler.isDone)
            {
                yield return null;
            }
            onComplete?.Invoke();
        }
    }
}