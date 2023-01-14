using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.Logic
{
    public class Curtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _duration = 1f;
        [SerializeField] private Slider _loadingBar;
        public UnityEvent FinishEvent;
        private void Start()
        {
            FadeIn();
            _loadingBar.value = 0;
        }

        private void Update() {
            _loadingBar.DOValue(1, _duration);
        }
        public void FadeIn(Action callback = null)
        {
            _canvasGroup.gameObject.SetActive(true);
            _canvasGroup.alpha = 1f;
            
            _canvasGroup.DOFade(0f, _duration)
                .OnComplete
                (
                    () =>
                    {
                        FinishEvent?.Invoke ();
                        _canvasGroup.gameObject.SetActive(false);
                        callback?.Invoke();
                    }
                );
            
        }
    }
}