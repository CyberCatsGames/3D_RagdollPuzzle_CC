using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.HeroComponents
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _bar;

        public void SetValue(int current, int max)
        {
            _bar.fillAmount = (float)current / max;
        }
    }
}