using UnityEngine;

namespace CodeBase.HeroComponents
{
    public class ShowWinPanelComponent : MonoBehaviour
    {
        private WinPanel _winPanel;

        private bool _isShowed;

        private void Awake()
        {
            _winPanel = FindObjectOfType<WinPanel>();
        }

        public void Show()
        {
            if (_isShowed == true)
                return;
            
            _isShowed = true;
            _winPanel.Show();
        }
    }
}