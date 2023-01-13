using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.HeroComponents
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _bar;

        public void SetValue(int current, int max)
        {
            _bar.value = (float)current / max;
        }
    }
}