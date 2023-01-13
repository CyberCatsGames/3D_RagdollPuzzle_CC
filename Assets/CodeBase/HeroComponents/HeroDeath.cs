using UnityEngine;

namespace CodeBase.HeroComponents
{
    [RequireComponent(typeof(HeroHealth))]
    public class HeroDeath : MonoBehaviour
    {
        private HeroHealth _health;
        private LosePanel _losePanel;

        private void Awake()
        {
            _health = GetComponent<HeroHealth>();
            _losePanel = FindObjectOfType<LosePanel>();
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
            _losePanel.Show();
        }
    }
}