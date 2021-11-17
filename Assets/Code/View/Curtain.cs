using DG.Tweening;
using UnityEngine;

namespace Code.View
{
    public class Curtain:MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvas;
        [SerializeField] private float _animationSpeed =0.1f;

        private void Awake()
        {
           DontDestroyOnLoad(this);
        }

        public void Show()
        {
            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
            }
            _canvas.alpha = 1;
        }

        public void Hide()
        {
            _canvas.DOFade(0, _animationSpeed).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
        
    }
}