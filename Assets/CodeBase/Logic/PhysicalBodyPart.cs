using UnityEngine;

namespace CodeBase.Logic
{
    [RequireComponent(typeof(ConfigurableJoint))]
    public class PhysicalBodyPart : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private bool _isArm;

        private ConfigurableJoint _joint;
        private Quaternion _startRotation;

        private void Awake()
        {
            _joint = GetComponent<ConfigurableJoint>();
            _startRotation = transform.rotation;
        }

        private void FixedUpdate()
        {
            //Quaternion targetRotation = Quaternion.Inverse(_target.localRotation) * _startRotation;
            Quaternion targetRotation = _target.localRotation;

            if (_isArm == true)
            {
                var targetRotationEuler = targetRotation.eulerAngles;
                _joint.targetRotation = Quaternion.Euler
                (
                    new Vector3(targetRotationEuler.z, targetRotationEuler.y, targetRotationEuler.x)
                );
            }
            else
            {
                _joint.targetRotation = targetRotation;
            }
        }
    }
}