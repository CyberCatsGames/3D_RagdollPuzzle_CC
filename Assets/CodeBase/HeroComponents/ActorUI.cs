using UnityEngine;

namespace CodeBase.HeroComponents
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private HeroHealth _heroHealth;

        private void OnEnable()
        {
            _heroHealth.Changed += OnHealthChanged;
        }

        private void OnDisable()
        {
            _heroHealth.Changed += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            _healthBar.SetValue(_heroHealth.Current, _heroHealth.Max);
        }
    }
}