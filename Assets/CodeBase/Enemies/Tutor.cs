using ARP.APR.Scripts;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Enemies
{
    public class Tutor : MonoBehaviour
    {
        [SerializeField] private float _duration = 1f;
        [SerializeField] private CanvasGroup _canvasGroup;

        private APRController _input;

        private void Awake()
        {
            _input = FindObjectOfType<Naruto>().GetComponent<APRController>();
        }

        private void Start()
        {
            Invoke(nameof(Show), 1f);
            Invoke(nameof(Close), 8f);
        }

        private void Show()
        {
            _input.useControls = false;
            _canvasGroup.gameObject.SetActive(true);
            _canvasGroup.alpha = 0f;
            _canvasGroup.DOFade(1f, _duration);
        }

        public void Close()
        {
            _canvasGroup.DOFade(0f, 0.5f)
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