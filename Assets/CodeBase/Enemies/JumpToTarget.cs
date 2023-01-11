using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class JumpToTarget : MonoBehaviour
    {
        [SerializeField] private float _jumpPower = 20f;
        [SerializeField] private float _duration = 1f;

        private NavMeshAgent _agent;
        private Collider _collider;
        private Rigidbody _rigidbody;
        private bool _isJumping;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _agent = GetComponent<NavMeshAgent>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void TryJump(Transform target, Action callback)
        {
            if (_isJumping == true)
                return;

            _collider.enabled = true;
            _agent.enabled = false;
            _isJumping = true;
            Jump(target, callback);
        }

        private void Jump(Transform target, Action callback)
        {
            _rigidbody.DOJump(target.position, _jumpPower, 1, _duration)
                .OnComplete(() => OnJumpFinished(callback));
        }

        private void OnJumpFinished(Action callback)
        {
            _isJumping = false;
            _collider.enabled = false;
            _agent.enabled = true;
            callback?.Invoke();
        }
    }
}