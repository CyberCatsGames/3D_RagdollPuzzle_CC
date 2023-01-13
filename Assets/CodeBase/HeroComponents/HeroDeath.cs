using ARP.APR.Scripts;
using UnityEngine;

namespace CodeBase.HeroComponents
{
    [RequireComponent(typeof(HeroHealth))]
    public class HeroDeath : MonoBehaviour
    {
        private HeroHealth _health;
        private LosePanel _losePanel;
        private bool _isDied;

        private void Awake()
        {
            _health = GetComponent<HeroHealth>();
        }

        private void OnEnable()
        {
            _health.Changed += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.Changed -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (_isDied || _health.Current > 0)
                return;

            Die();
        }

        private void Die()
        {
            _isDied = true;
            APRController aprController = transform.root.GetComponent<APRController>();
            aprController.autoGetUpWhenPossible = false;
            aprController.canBeKnockoutByImpact = false;
            aprController.useStepPrediction = false;
            aprController.useControls = false;

            foreach (ConfigurableJoint componentsInChild in aprController.GetComponentsInChildren<ConfigurableJoint>())
            {
                JointDrive angularXDrive = componentsInChild.angularXDrive;
                angularXDrive.positionSpring = 0f;
                componentsInChild.angularXDrive = angularXDrive;
            }

            LosePanel.Instance.Show();
        }
    }
}