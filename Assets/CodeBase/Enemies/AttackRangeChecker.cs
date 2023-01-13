using UnityEngine;

namespace CodeBase.Enemies
{
    public class AttackRangeChecker : MonoBehaviour
    {
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private TriggerObserver _triggerObserver;

        private void OnEnable()
        {
            _triggerObserver.TriggerEnter += TriggerEnter;
            _triggerObserver.TriggerExit += TriggerExit;
        }

        private void Start()
        {
            _enemyAttack.DisableAttack();
        }

        private void TriggerEnter(Collider obj)
        {
            _enemyAttack.EnableAttack();
        }

        private void TriggerExit(Collider obj)
        {
            _enemyAttack.DisableAttack();
        }
    }
}