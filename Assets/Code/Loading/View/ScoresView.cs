using System;
using Code.Loading.Abstraction;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoresView:MonoBehaviour, IListener<int>
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void Init(Code.Loading.Abstraction.IObserver<int> observer)
        {
            observer.Subscribe(this);
        }
        public void ChangeValue(int value)
        {
            _text.text = $"Scores: {value}";
        }
    }
}