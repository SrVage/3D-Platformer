using Code.Abstraction;
using TMPro;
using UnityEngine;

namespace Code.View
{
    public class ScoresView:MonoBehaviour, IListener<int>
    {
        [SerializeField] private TextMeshProUGUI _text;
        private IObserver<int> _observer;

        public void Init(IObserver<int> observer)
        {
            observer.Subscribe(this);
            _observer = observer;
        }
        public void ChangeValue(int value)
        {
            _text.text = $"Scores: {value}";
        }

        private void OnDestroy()
        {
            _observer.Unsubscribe(this);
        }
    }
}