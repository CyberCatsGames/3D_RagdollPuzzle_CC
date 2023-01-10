using System;
using CodeBase.HeroComponents;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private Hero _hero;

        private void Start()
        {
            _hero = FindObjectOfType<Hero>();
        }

        private void Update()
        {
            _agent.destination = _hero.transform.position;
        }
    }
}