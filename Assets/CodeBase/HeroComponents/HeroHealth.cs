using System;
using UnityEngine;

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
}