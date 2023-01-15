using ARP.APR.Scripts;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Enemies
{
    public class Tutor : MonoBehaviour
    {
        [SerializeField] private float _fadeDuration = 1f;
        [SerializeField] private float _lifeTime = 1f;
        [SerializeField] private float _startDelay = 1f;
        [SerializeField] private CanvasGroup _canvasGroup;

        private APRController _input;

        private void Awake()
        {
            _input = FindObjectOfType<Naruto>().GetComponent<APRController>();
            _canvasGroup.alpha = 0f;
        }

        private void Start()
        {
            Invoke(nameof(Show), _startDelay);
            Invoke(nameof(Close), _lifeTime);
        }

        private void Show()
        {
            _input.useControls = false;
            _canvasGroup.gameObject.SetActive(true);
            _canvasGroup.alpha = 0f;
            _canvasGroup.DOFade(1f, _fadeDuration);
        }

        public void Close()
        {
            _canvasGroup.DOFade(0f, _fadeDuration)
                .OnComplete
                (
                    () =>
                    {
                        _canvasGroup.gameObject.SetActive(false);
                        _input.useControls = true;
                    }
                );
        }
    }
}