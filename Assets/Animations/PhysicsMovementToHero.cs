using System;
using CodeBase.HeroComponents;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(ConfigurableJoint))]
    public class PhysicsMovementToHero : MonoBehaviour
    {
        private Hero _hero;
        private ConfigurableJoint _joint;

        private void Awake()
        {
            _joint = GetComponent<ConfigurableJoint>();
        }

        private void Start()
        {
            _hero = FindObjectOfType<Hero>();
        }

        private void FixedUpdate()
        {
            Vector3 direction = (_hero.transform.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
            _joint.targetRotation = Quaternion.Inverse(targetRotation);
        }
    }
}