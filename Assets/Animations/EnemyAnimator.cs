using UnityEngine;

namespace Animations
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private static readonly int AttackAnimation = Animator.StringToHash("Attack");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        public void Attack()
        {
            _animator.SetTrigger(AttackAnimation);
        }

        public void StartMoving()
        {
            _animator.SetBool(IsMoving, true);
        }

        public void StopMoving()
        {
            _animator.SetBool(IsMoving, false);
        }
    }
}