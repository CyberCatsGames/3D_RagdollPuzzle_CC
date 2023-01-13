using System;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.HeroComponents
{
    public class HeroHealth : MonoBehaviour
    {
        [SerializeField] private int _value;
        [SerializeField] private UnityEvent _onTakeDamage;

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

            _onTakeDamage?.Invoke();
            _value -= damage;
            Changed?.Invoke();
        }
    }
}