using UnityEngine;

namespace Animations
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private static readonly int AttackAnimation = Animator.StringToHash("Attack");
        private static readonly int MoveAnimation = Animator.StringToHash("Move");

        public void Attack()
        {
            _animator.SetTrigger(AttackAnimation);
        }

        public void Move(float speed)
        {
            _animator.SetFloat(MoveAnimation, speed);
        }
    }
}