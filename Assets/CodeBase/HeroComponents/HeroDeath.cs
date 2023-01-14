using ARP.APR.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.HeroComponents
{
    [RequireComponent(typeof(HeroHealth))]
    public class HeroDeath : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onDeath;

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

        [ContextMenu("Die")]
        public void Die()
        {
            _onDeath?.Invoke();
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

            CY_GtaEffect.Instance.gameObject.SetActive(true);
        }
    }
}