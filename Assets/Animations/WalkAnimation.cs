using UnityEngine;

namespace Animations
{
    public class WalkAnimation : MonoBehaviour
    {
        [SerializeField] private PhysicMaterial _defaultFriction;
        [SerializeField] private PhysicMaterial _zeroFriction;

        [SerializeField] private Collider _leftCollider;
        [SerializeField] private Collider _rightCollider;

        public void SetLeftFriction()
        {
            _leftCollider.material = _defaultFriction;
            _rightCollider.material = _zeroFriction;
        }

        public void SetRightFriction()
        {
            _rightCollider.material = _defaultFriction;
            _leftCollider.material = _zeroFriction;
        }
    }
}