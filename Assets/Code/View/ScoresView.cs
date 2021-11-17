using Code.Abstraction;
using TMPro;
using UnityEngine;

namespace Code.View
{
    public class ScoresView:MonoBehaviour, IListener<int>
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void Init(Abstraction.IObserver<int> observer)
        {
            observer.Subscribe(this);
        }
        public void ChangeValue(int value)
        {
            _text.text = $"Scores: {value}";
        }
    }
}