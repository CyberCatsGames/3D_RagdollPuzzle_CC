using TurnTheGameOn.Timer;
using UnityEngine;

namespace CodeBase.Enemies
{
    public class SetTimeWithConditions : MonoBehaviour
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private float _firstSetup = 101f;
        [SerializeField] private float _secondSetup = 20f;
        [SerializeField] private GameObject _funnyVideo;

        private void Awake()
        {
            _timer.startTime = CurrentSceneManager.Instance.Level > 0 ? _secondSetup : _firstSetup;
            Invoke(nameof(ActivateFunnyVideo), 10f);
        }

        public void ActivateFunnyVideo()
        {
            _funnyVideo.SetActive(true);
        }
    }
}