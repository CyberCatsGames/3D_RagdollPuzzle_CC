using System.Collections.Generic;
using DG.Tweening;
using ForJump.ForJump;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemies
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentJumpToTarget : MonoBehaviour
    {
        [SerializeField] private GameObject Target;
        public float ReachedStartPointDistance = 0.5f;
        public Transform DummyAgent;
        public Vector3 EndJumpPosition;
        public float MaxJumpableDistance = 80f;
        public float JumpTime = 0.6f;
        public float AddToJumpHeight;

        private Transform _dummyAgent;
        public Vector3 JumpStartPoint;
        private Vector3 JumpMidPoint;
        private Vector3 JumpEndPoint;
        private bool checkForStartPointReached;
        private Transform _transform;
        private List<Vector3> Path = new List<Vector3>();
        private float JumpDistance;
        private Vector3[] _jumpPath;
        private bool previousRigidBodyState;

        private NavMeshAgent _agent;
        private Rigidbody _rigidbody;

        // remove the [Button] code if you don't have Odin
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _agent = GetComponent<NavMeshAgent>();
        }

        [ContextMenu("Get Start Point and Move To Position")]
        public void GetStartPointAndMoveToPosition()
        {
            JumpStartPoint = GetJumpStartPoint();
            MoveToStartPoint();
        }

        [ContextMenu("Jump")]
        // remove the [Button] code if you don't have Odin
        public void PerformJump()
        {
            SpawnAgentAndGetPoint();
        }

        private void OnEnable()
        {
            checkForStartPointReached = false;
            _transform = transform;
        }

        private Vector3 GetJumpStartPoint()
        {
            NavMeshPath hostAgentPath = new NavMeshPath();
            _agent.CalculatePath(Target.transform.position, hostAgentPath);
            var endPointIndex = hostAgentPath.corners.Length - 1;
            return hostAgentPath.corners[endPointIndex];

            //Improvement to make- get the jump distance using the start and end point
            // use that to set the Jump Time
        }

        private void MoveToStartPoint()
        {
            checkForStartPointReached = true;
            _agent.isStopped = false;
            _agent.SetDestination(JumpStartPoint);
        }

        private void ReadyToJump()
        {
            //Do your pre_jump animation
        }

        private void SpawnAgentAndGetPoint()
        {
            // If using Pooling Spawn here instead
            _dummyAgent = Instantiate(DummyAgent, Target.transform.position, Quaternion.identity);
            var info = _dummyAgent.GetComponent<ReturnNavmeshInfo>();
            EndJumpPosition = info.ReturnClosestPointBackToAgent(transform.position);
            JumpEndPoint = EndJumpPosition;

            MakeJumpPath();
        }

        private void MakeJumpPath()
        {
            Path.Add(JumpStartPoint);

            var tempMid = Vector3.Lerp(JumpStartPoint, JumpEndPoint, 0.5f);
            tempMid.y = tempMid.y + _agent.height + AddToJumpHeight;

            Path.Add(tempMid);

            Path.Add(JumpEndPoint);

            JumpDistance = Vector3.Distance(JumpStartPoint, JumpEndPoint);

            if (JumpDistance <= MaxJumpableDistance)
            {
                DoJump();
            }
            else
            {
                Debug.Log("Too far to jump");
            }
        }

        private void DoJump()
        {
            previousRigidBodyState = _rigidbody.isKinematic;
            _agent.enabled = false;
            _rigidbody.isKinematic = true;

            _jumpPath = Path.ToArray();

            // if you don't want to use a RigidBody change this to
            //transform.DoLocalPath per the DoTween doc's
            _rigidbody.DOLocalPath(_jumpPath, JumpTime, PathType.CatmullRom).OnComplete(JumpFinished);
        }

        private void JumpFinished()
        {
            _agent.enabled = true;
            _rigidbody.isKinematic = previousRigidBodyState;

            // If using Pooling DeSpawn here instead
            Destroy(_dummyAgent.gameObject);
        }

        private void Update()
        {
            if (checkForStartPointReached)
            {
                var distance = (_transform.position - JumpStartPoint).sqrMagnitude;

                if (distance <= ReachedStartPointDistance * ReachedStartPointDistance)
                {
                    ReadyToJump();

                    if (_agent.isOnNavMesh)
                    {
                        _agent.isStopped = true;
                    }

                    checkForStartPointReached = false;
                }
            }
        }
    }
}