using DG.Tweening;
using UnityEngine;

namespace CodeBase.HeroComponents
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Window : MonoBehaviour
    {
        [SerializeField] private float _duration = 1f;
            
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _canvasGroup.DOFade(1f, _duration);
        }

        public void Hide()
        {
            _canvasGroup.DOFade(0f, _duration)
                .OnComplete(() => _canvasGroup.gameObject.SetActive(false));
        }
    }
}