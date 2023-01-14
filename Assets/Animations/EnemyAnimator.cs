using UnityEngine;

namespace Animations
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private static readonly int AttackAnimation1 = Animator.StringToHash("Attack1");
        private static readonly int AttackAnimation2 = Animator.StringToHash("Attack2");
        private static readonly int AttackAnimation3 = Animator.StringToHash("Attack3");
        private static readonly int AttackAnimation4 = Animator.StringToHash("Attack4");
        private static readonly int AttackAnimation5 = Animator.StringToHash("Attack5");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        public void Attack1()
        {
            _animator.SetTrigger(AttackAnimation1);
        }

        public void Attack2()
        {
            _animator.SetTrigger(AttackAnimation2);
        }

        public void Attack3()
        {
            _animator.SetTrigger(AttackAnimation3);
        }

        public void Attack4()
        {
            _animator.SetTrigger(AttackAnimation4);
        }

        public void Attack5()
        {
            _animator.SetTrigger(AttackAnimation5);
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