using System;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Logic
{
    public class Curtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _duration = 1f;

        private void Awake()
        {
            FadeIn();
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
                        _canvasGroup.gameObject.SetActive(false);
                        callback?.Invoke();
                    }
                );
        }
    }
}