using CodeBase.HeroComponents;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private HeroHealth[] _heroes;

        private HeroHealth NearHero
        {
            get
            {
                HeroHealth nearHero = _heroes[0];
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
        }
    }
}