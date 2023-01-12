using UnityEngine;

namespace Animations
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _enemyAnimator;

        private void Awake()
        {
            _enemyAnimator.transform.parent = null;
            _enemyAnimator.transform.position = Vector3.down * 1_000_000;
        }
    }
}