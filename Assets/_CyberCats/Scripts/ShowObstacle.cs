using System;
using CodeBase.Enemies;
using DG.Tweening;
using UnityEngine;

namespace _CyberCats.Scenes.Scripts
{
    public class ShowObstacle : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private float _duration = 4f;
        [SerializeField] private float _delay = 7.5f;

        private Vector3 _finishScale;

        private void Awake()
        {
            _finishScale = transform.localScale;
            transform.localScale = Vector3.zero;
        }

        private void OnEnable()
        {
            _triggerObserver.TriggerEnter += DoScaleAnimation;
        }

        private void DoScaleAnimation(Collider collider1)
        {
            _triggerObserver.TriggerEnter -= DoScaleAnimation;
            transform.DOScale(_finishScale, _duration);
        }
    }
}