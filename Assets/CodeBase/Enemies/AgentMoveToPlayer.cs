using Animations;
using CodeBase.HeroComponents;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private float _velocityToStartWalkAnimation = 0.01f;

        private HeroHealth nearHero;
        private HeroHealth[] _heroes;

        private HeroHealth NearHero
        {
            get
            {
                nearHero = _heroes[0];
                float littleDistance = float.MaxValue;

                foreach (HeroHealth hero in _heroes)
                {
                    float distance = Vector3.Distance(transform.position, hero.transform.position);

                    if (distance < littleDistance)
                    {
                        nearHero = hero;
                        littleDistance = distance;
                    }
                }

                return nearHero;
            }
        }

        private void Start()
        {
            _heroes = FindObjectsOfType<HeroHealth>();
        }

        private void Update()
        {
            _agent.destination = NearHero.transform.position;

            if (ShouldMove())
            {
                _enemyAnimator.StartMoving();
            }
            else
            {
                _agent.updateRotation = true;
                _enemyAnimator.StopMoving();
            }
        }

        private bool ShouldMove()
        {
            float distance = Vector3.Distance(nearHero.transform.position, transform.position);
            return distance > 3f;
        }
    }
}