using DG.Tweening;
using UnityEngine;

namespace _CyberCats.Scenes.Scripts
{
    public class ShowObstacle : MonoBehaviour
    {
        [SerializeField] private float _duration = 4f;
        [SerializeField] private float _delay = 6f;

        private Vector3 _finishScale;

        private void Awake()
        {
            _finishScale = transform.localScale;
            transform.localScale = Vector3.zero;
        }

        private void Start()
        {
            Invoke(nameof(DoScaleAnimation), _delay);
        }

        private void DoScaleAnimation()
        {
            transform.DOScale(_finishScale, _duration);
        }
    }
}