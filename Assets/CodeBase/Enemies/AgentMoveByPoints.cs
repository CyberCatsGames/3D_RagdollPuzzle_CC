using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMoveByPoints : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;

        private NavMeshAgent _agent;
        private int _currentPointIndex;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.stoppingDistance = 0f;

            foreach (Transform point in _points)
            {
                point.parent = null;
            }
        }

        private void Update()
        {
            Transform targetPoint = _points[_currentPointIndex];

            if (transform.EqualsByXZ(targetPoint))
            {
                _currentPointIndex++;

                if (_currentPointIndex >= _points.Length)
                    enabled = false;
            }
            else
            {
                _agent.destination = targetPoint.position;
            }
        }
    }
}