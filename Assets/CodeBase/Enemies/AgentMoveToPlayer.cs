using CodeBase.HeroComponents;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private GameObject _hero;

        private void Start()
        {
            if (_hero == null)
                _hero = FindObjectOfType<Hero>().gameObject;
        }

        private void Update()
        {
            _agent.destination = _hero.transform.position;
        }
    }
}