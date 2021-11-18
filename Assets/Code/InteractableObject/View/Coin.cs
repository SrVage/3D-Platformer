﻿using Code.Abstraction;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Code.InteractableObject.View
{
    public class Coin:MonoBehaviour, IInteract
    {
        private UnityAction _action;
        public void Init(UnityAction changeScores)
        {
            _action = changeScores;
            Rotate();
        }

        private void Rotate()
        {
            transform.DOShakeRotation(2, Vector3.up*50, 2, 90, false).OnComplete(Rotate);
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