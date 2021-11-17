using System.Collections;
using UnityEngine;

namespace Code.Loading.Abstraction
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}