using System.Linq;
using Animations;
using CodeBase.HeroComponents;
using UnityEngine;

namespace CodeBase.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float _cooldown = 2f;
        [SerializeField] private float _damageRadius = 1f;
        [SerializeField] private int _damage = 1;
        [SerializeField] private EnemyAnimator _enemyAnimator;

        private readonly Collider[] _results = new Collider[1];
        private Transform _heroTransform;
        private float _cooldownTimer;
        private bool _isAttacking;
        private int _layerMask;
        private bool _attackIsEnabled;

        private bool CanAttack => _attackIsEnabled == true && _isAttacking == false && _cooldownTimer <= 0f;

        private Vector3 StartPoint => transform.position + new Vector3(0f, 0.5f, 1f);

        private void Awake()
        {
            _layerMask = 1 << LayerMask.NameToLayer("Player_1");
        }

        private void Update()
        {
            _cooldownTimer -= Time.deltaTime;

            if (CanAttack)
                StartAttack();
        }

        public void EnableAttack()
        {
            _attackIsEnabled = true;
        }

        public void DisableAttack()
        {
            _attackIsEnabled = false;
        }

        public void OnAttack()
        {
            if (TryHit(out Collider hit))
            {
                hit.GetComponent<HeroHealth>().TakeDamage(_damage);
            }
        }

        public void OnAttackEnded()
        {
            _cooldownTimer = _cooldown;
            _isAttacking = false;
        }

        private void StartAttack()
        {
            _isAttacking = true;
            _enemyAnimator.Attack();
            transform.LookAt(_heroTransform);
        }

        private bool TryHit(out Collider hit)
        {
            int hitCount = Physics.OverlapSphereNonAlloc(StartPoint, _damageRadius, _results, _layerMask);
            hit = _results.FirstOrDefault();
            return hitCount > 0;
        }
    }
}