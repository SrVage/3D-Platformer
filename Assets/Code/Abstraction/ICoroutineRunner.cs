using System.Collections;
using UnityEngine;

namespace Code.Abstraction
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}