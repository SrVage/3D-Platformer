using System.Collections.Generic;
using Code.Abstraction;
using UnityEngine;

namespace Code.Loading.Model
{
    public class Scores<T>:IObserver<int>
    {
        private List<IListener<int>> _listeners;
        private int _score;

        public Scores()
        {
            _score = 0;
            _listeners = new List<IListener<int>>();
        }
        
        public int Score
        {
            get => _score;
            private set
            {
                _score = value;
                Observe();
            }
        }

        public void AddScore()
        {
            Score += 1;
        }

        public void Subscribe(IListener<int> listener)
        {
            _listeners.Add(listener);
        }

        public void Unsubscribe(IListener<int> listener)
        {
            _listeners.Remove(listener);
        }

        public void Observe()
        {
            foreach (var listener in _listeners)
            {
                listener.ChangeValue(Score);
            }
        }
    }
}