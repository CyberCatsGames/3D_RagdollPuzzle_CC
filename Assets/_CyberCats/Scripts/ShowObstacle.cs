using CodeBase.Enemies;
using DG.Tweening;
using UnityEngine;

namespace _CyberCats.Scenes.Scripts
{
    public class ShowObstacle : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private float _duration = 4f;
        [SerializeField] private Transform _checkRange;

        private Vector3 _finishScale;

        private void Awake()
        {
            if (_checkRange != null)
                _checkRange.transform.parent = null;

            _finishScale = transform.localScale;
            transform.localScale = Vector3.zero;
            _triggerObserver.TriggerEnter += DoScaleAnimation;
        }

        private void DoScaleAnimation(Collider collider1)
        {
            _triggerObserver.TriggerEnter -= DoScaleAnimation;
            transform.DOScale(_finishScale, _duration);
        }
    }
}