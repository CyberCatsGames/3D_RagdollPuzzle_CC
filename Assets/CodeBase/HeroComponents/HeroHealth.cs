using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.HeroComponents
{
    public class HeroHealth : MonoBehaviour
    {
        [SerializeField] private int _value;

        public int Current => _value;
        public int Max { get; private set; }

        public event Action Changed;

        private void Awake()
        {
            Max = _value;
        }

        public void TakeDamage(int damage)
        {
            if (_value <= 0)
                return;

            _value -= damage;
            Changed?.Invoke();
        }
    }

    [RequireComponent(typeof(HeroHealth))]
    public class HeroDeath : MonoBehaviour
    {
        private HeroHealth _health;

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
            if (_health.Current > 0)
                return;

            Die();
        }

        private void Die()
        {
        }
    }

    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _bar;

        public void SetValue(int current, int max)
        {
            _bar.fillAmount = (float)current / max;
        }
    }

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