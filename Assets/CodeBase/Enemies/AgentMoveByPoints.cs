using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemies
{
    [RequireComponent(typeof(JumpToTarget))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMoveByPoints : MonoBehaviour
    {
        private TargetPoint[] _points;
        private JumpToTarget _jumper;
        private int _currentPointIndex;
        private NavMeshAgent _agent;

        private void Awake()
        {
            _points = GetComponentsInChildren<TargetPoint>();
            _jumper = GetComponent<JumpToTarget>();
            _agent = GetComponent<NavMeshAgent>();

            foreach (TargetPoint point in _points)
            {
                point.transform.parent = null;
            }
        }

        private void Update()
        {
            if (_currentPointIndex >= _points.Length)
            {
                enabled = false;
                return;
            }

            TargetPoint targetPoint = _points[_currentPointIndex];

            switch (targetPoint)
            {
                case JumpPoint:
                    _jumper.TryJump(targetPoint.transform, () => _currentPointIndex++);
                    break;
                case MovePoint:
                    if (_agent.enabled == true)
                        _agent.destination = targetPoint.transform.position;

                    if (transform.EqualsByXZRoundInt(targetPoint.transform))
                    {
                        _currentPointIndex++;
                    }

                    break;
            }
        }
    }
}