using System.Collections.Generic;
using Code.Abstraction;

namespace Code.Loading.Model
{
    public class Scores<T>:IObserver<int>
    {
        public int MaxScores { get; private set; }
        private List<IListener<int>> _listeners;
        private List<IListenerLevel<int>> _finisher;
        private int _score;

        public Scores(int maxScores)
        {
            _score = 0;
            MaxScores = maxScores;
            _listeners = new List<IListener<int>>();
            _finisher = new List<IListenerLevel<int>>();
        }
        
        public int Score
        {
            get => _score;
            private set
            {
                _score = value;
                Observe();
                if (_score == MaxScores)
                    Finish();
            }
        }

        public void AddScore()
        {
            Score += 1;
        }

        public void Subscribe(IListener<int> listener)
        {
            if (listener is IListenerLevel<int> finish)
                _finisher.Add(finish);
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

        public void Finish()
        {
            foreach (var finisher in _finisher)
            {
                finisher.Finish();
            }
        }
    }
}