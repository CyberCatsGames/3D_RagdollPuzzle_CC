using UnityEngine;

namespace CodeBase.HeroComponents
{
    public class ShowWinPanelComponent : MonoBehaviour
    {
        private bool _isShowed;

        public void Show()
        {
            if (_isShowed == true)
                return;

            _isShowed = true;
            WinPanel.Instance.Show();
        }
    }
}