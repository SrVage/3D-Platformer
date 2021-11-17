using Code.Loading.Abstraction;
using Code.Loading.Model;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Code.Loading.InteractableObject.View
{
    public class Coin:MonoBehaviour, IInteract
    {
        private UnityAction _action;
        public void Init(UnityAction changeScores)
        {
            _action = changeScores;
        }
        public void Interact()
        {
            transform.DOScale(Vector3.zero, 1f).OnComplete(Destroy);
        }

        private void Destroy()
        {
            _action?.Invoke();
            Destroy(gameObject);
        }
    }
}